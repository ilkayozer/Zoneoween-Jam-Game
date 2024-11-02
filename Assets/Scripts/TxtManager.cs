using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public TMP_Text textBubble;
    public Button bottomText;
    public float typingSpeed = 0.05f;
    public float waitTime = 2f;
    public bool isClicked = false;

    private NpcManager npcManager;
    private int dialogIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        npcManager = FindAnyObjectByType<NpcManager>();

        //if (npcObject != null)
        //    npcManager = npcObject.GetComponent<NpcManager>();
        bottomText.onClick.AddListener(OnBottomTextClicked);

    }

    public void OnBottomTextClicked()
    {
        if (!isTyping)
        {
            ShowNextDialog();

            Destroy(bottomText.gameObject);
            isClicked = true;

            //StartCoroutine(Wait(waitTime));

        }
    }

    public float GetTypeingTime(int dialogIndex)
    {
        float typeTotalTime = typingSpeed * (npcManager.GetDialog(dialogIndex)).Length;
        return typeTotalTime;
    }

    public void ShowNextDialog()
    {
        StartCoroutine(TypeText(npcManager.GetDialog(dialogIndex)));
        dialogIndex++;
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ShowNextDialog();
    }

    private IEnumerator TypeText(string newText)
    {
        isTyping = true;
        foreach (char letter in newText.ToCharArray())
        {
            textBubble.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

}
