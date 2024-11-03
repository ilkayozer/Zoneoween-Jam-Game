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
        yield return new WaitForSeconds(DoorManager.doorMoveDistance * DoorManager.doorSpeed);

        TextManager.ShowNextDialog();
        Debug.Log("ilk dialog");
        yield return new WaitForSeconds(TextManager.GetTypeingTime(2));
        while (!(PlayerStats.isDenied || PlayerStats.isLetIn))
        {
            yield return new WaitForSeconds(1f); // Tuþ basýlana kadar bekliyor (ÇALIÞIYO)
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
        Debug.Log("Rutin suratý");
    }
    private IEnumerator DenyOption()
    {
        TextManager.ClearText();
        DoorManager.Close();
        yield return new WaitForSeconds(DoorManager.doorSpeed * DoorManager.doorMoveDistance + 1f);
        npcManager = FindAnyObjectByType<NpcManager>();

        if (!npcManager.isEvil)
        {
            AlarmButton.gameObject.SetActive(true);
            QuickTimeEvent.isButtonShowed = true;
            while (QuickTimeEvent.isButtonShowed)
            {
                yield return new WaitForSeconds(1f);
            }
            AlarmButton.gameObject.SetActive(false);



        }
        Debug.Log("Deny");
        RoutineStarter();
    }

    private IEnumerator LetInOption()
    {
        Debug.Log("LetIn");
        TextManager.ClearText();
        DoorManager.Close();
        yield return new WaitForSeconds(DoorManager.doorSpeed * DoorManager.doorMoveDistance + 1f);
        npcManager = FindAnyObjectByType<NpcManager>();

        if (npcManager.isEvil)
        {
            AlarmButton.gameObject.SetActive(true);
            QuickTimeEvent.isButtonShowed = true;
            while (QuickTimeEvent.isButtonShowed)
            {
                yield return new WaitForSeconds(1f);
            }
            AlarmButton.gameObject.SetActive(false);



        }

        //içeri gircek, doðruysa üstte inicek (baþka sequence a), yanlýþ ise eleman yok olucak ve quick time event olucak.
        //yield return new WaitForSeconds(5f); //placeholder to code to work, return gerekiyor
        RoutineStarter();
    }

    private IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}
