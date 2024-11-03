using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour
{
    public Button IntroButton;

    private Button nextSceneButton;
    private float duration;
    private DoorMovement doorManager;
    private TextManager textManager;

    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;
    // Start is called before the first frame update

    private void Awake()
    {
        textManager = FindAnyObjectByType<TextManager>();
        textManager.isIntro = true;
    }

    void Start()
    {
        nextSceneButton = IntroButton.GetComponent<Button>();
        doorManager = FindAnyObjectByType<DoorMovement>();
        
        
        //Door waiting time
        //float duration = doorManager.doorMoveDistance * doorManager.doorSpeed;
        StartCoroutine(StartSeq(duration));

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator StartSeq(float duration)
    {
        doorManager.Open();
        doorOpenSound.Play();
        duration = doorManager.doorMoveDistance * doorManager.doorSpeed;

        yield return new WaitForSeconds(duration);
        textManager.ShowNextDialog();

        /*while (!textManager.isClicked)
        {
            yield return new WaitForSeconds(1);
        }*/

        yield return new WaitForSeconds(textManager.GetTypeingTime(0)+2f);
        textManager.ClearText();

        textManager.ShowNextDialog();
        yield return new WaitForSeconds(textManager.GetTypeingTime(1)+1f);
        textManager.ShowNextDialog();
        yield return new WaitForSeconds(textManager.GetTypeingTime(2) + 1f);
        textManager.ShowNextDialog();
        yield return new WaitForSeconds(textManager.GetTypeingTime(3) + 1f);
        textManager.ShowNextDialog();
        yield return new WaitForSeconds(textManager.GetTypeingTime(4) + 1f);
        textManager.ShowNextDialog();
        yield return new WaitForSeconds(textManager.GetTypeingTime(5) + 1f);
        textManager.ClearText();

        textManager.ShowNextDialog();
        yield return new WaitForSeconds(textManager.GetTypeingTime(6) + 1.5f);
        doorManager.Close();
        doorCloseSound.Play();

        textManager.ClearText();
        yield return new WaitForSeconds(duration);

        nextSceneButton.gameObject.SetActive(true);
    }

}
