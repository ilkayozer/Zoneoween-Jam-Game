using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonSceneManager : MonoBehaviour
{
    public DoorMovement doorManager;
    public TMP_Text Talk;
    public NpcManager Jesus;

    public float typingSpeed = 0.05f;
    public float waitTime = 2f;

    private int dialogIndex = 0;
    private bool isTyping = false;

    // Start is called before the first frame update
    void Start()
    {
        
        seqTest();

    }

    void seqTest()
    {
        StartCoroutine(Seq());
    }

    public float GetTypeingTime(int dialogIndex)
    {
        float typeTotalTime = typingSpeed * (Jesus.GetDialog(dialogIndex)).Length;
        return typeTotalTime;
    }

    public void ShowNextDialog()
    {
        Jesus = FindAnyObjectByType<NpcManager>();
        StartCoroutine(TypeText(Jesus.GetDialog(dialogIndex)));
        dialogIndex++;

    }

    private IEnumerator TypeText(string newText)
    {
        isTyping = true;
        foreach (char letter in newText.ToCharArray())
        {
            Talk.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    public void ClearText()
    {
        Talk.text = "";
    }

    public void ClearDialogIndex()
    {
        dialogIndex = 0;
    }

    private IEnumerator Seq() 
    {
        yield return new WaitForSeconds(doorManager.doorSpeed * doorManager.doorMoveDistance);
        doorManager.Open();
        yield return new WaitForSeconds(doorManager.doorSpeed * doorManager.doorMoveDistance);
        ShowNextDialog();
        yield return new WaitForSeconds(typingSpeed * waitTime + 3f);
        ClearText();
        ShowNextDialog();
        yield return new WaitForSeconds(typingSpeed * waitTime + 4f);
        doorManager.Close();
        yield return new WaitForSeconds(doorManager.doorSpeed * doorManager.doorMoveDistance);
        SceneManager.LoadScene(0);
    }
}
