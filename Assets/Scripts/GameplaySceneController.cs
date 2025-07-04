using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplaySceneController : MonoBehaviour
{
    private TextManager TextManager;
    private PlayerStatus PlayerStats;
    private CharSelect Spawner;
    private DoorMovement DoorManager;
    private NpcManager npcManager;
    public QuickTimeEvent QuickTimeEvent;

    public Button AlarmButton;
    public AudioSource alarmSound;

    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;

    //public AudioSource elevatorMoveSound;

    // Start is called before the first frame update
    void Start()
    {

        DoorManager = FindAnyObjectByType<DoorMovement>();
        Spawner = FindAnyObjectByType<CharSelect>();
        TextManager = FindAnyObjectByType<TextManager>();
        PlayerStats = FindAnyObjectByType<PlayerStatus>();

        RoutineStarter();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RoutineStarter()
    {
        TextManager.ClearText();
        TextManager.ClearDialogIndex();
        Spawner.SelectRandomChar();

        StartCoroutine(Routine());
       
    }
    private IEnumerator Routine()
    {
        
        yield return new WaitForSeconds(1f);
        DoorManager.Open();
        doorOpenSound.Play();
        yield return new WaitForSeconds(DoorManager.doorMoveDistance * DoorManager.doorSpeed);

        TextManager.ShowNextDialog();
        Debug.Log("ilk dialog");
        yield return new WaitForSeconds(TextManager.GetTypeingTime(2) + 1f);
        while (!(PlayerStats.isDenied || PlayerStats.isLetIn))
        {
            yield return new WaitForSeconds(1f); // Tu� bas�lana kadar bekliyor (�ALI�IYO)
        }
        if(PlayerStats.isDenied)
        {
            StartCoroutine(DenyOption());
            PlayerStats.isDenied = false;
        } else if(PlayerStats.isLetIn)
        {
            StartCoroutine(LetInOption());
            PlayerStats.isLetIn = false;
        }
        Debug.Log("Rutin surat�");
    }
    private IEnumerator DenyOption()
    {
        TextManager.ClearText();
        DoorManager.Close();
        doorCloseSound.Play();
        yield return new WaitForSeconds(DoorManager.doorSpeed * DoorManager.doorMoveDistance + 1f);

        

        npcManager = FindAnyObjectByType<NpcManager>();

        if (!npcManager.isEvil)
        {
            alarmSound.Play();
            AlarmButton.gameObject.SetActive(true);
            QuickTimeEvent.isButtonShowed = true;
            while (QuickTimeEvent.isButtonShowed)
            {
                yield return new WaitForSeconds(1f);
            }
            alarmSound.Stop();
            AlarmButton.gameObject.SetActive(false);



        }
        if (PlayerStats.isWon) //Win Condition
        {

        } else
        {
            Debug.Log("Deny");
            RoutineStarter();
        }
    }

    private IEnumerator LetInOption()
    {
        Debug.Log("LetIn");
        TextManager.ClearText();
        DoorManager.Close();
        doorCloseSound.Play();
        yield return new WaitForSeconds(DoorManager.doorSpeed * DoorManager.doorMoveDistance + 1f);

       

        npcManager = FindAnyObjectByType<NpcManager>();

        if (npcManager.isEvil)
        {
            alarmSound.Play();
            AlarmButton.gameObject.SetActive(true);
            QuickTimeEvent.isButtonShowed = true;
            while (QuickTimeEvent.isButtonShowed)
            {
                yield return new WaitForSeconds(1f);
            }
            alarmSound.Stop();
            AlarmButton.gameObject.SetActive(false);
        }

        //i�eri gircek, do�ruysa �stte inicek (ba�ka sequence a), yanl�� ise eleman yok olucak ve quick time event olucak.
        //yield return new WaitForSeconds(5f); //placeholder to code to work, return gerekiyor

        if (PlayerStats.isWon) //Win Condition
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            Debug.Log("LetIn");
            RoutineStarter();
        }
    }

    private IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}
