using System.Collections;
using TMPro;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    public float waitTime = 2f;
    public bool isClicked = false;
    public bool isIntro = false;
    public bool isDialogOver = false;

    public TMP_Text ButtonText;
    public TMP_Text textBubble;
    public Button bottomText;


    private TMP_Text textManager;
    private Button buttonManager;
    private NpcManager npcManager;
    private int dialogIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        //bottomText = FindAnyObjectByType<Button>();
        textManager = textBubble.GetComponent<TMP_Text>();
        buttonManager = bottomText.GetComponent<Button>();
        ButtonText= ButtonText.GetComponent<TMP_Text>();
        npcManager = FindAnyObjectByType<NpcManager>();

        //if (npcObject != null)
        //    npcManager = npcObject.GetComponent<NpcManager>();
        buttonManager.onClick.AddListener(OnBottomTextClicked);
    }

    public void OnBottomTextClicked()
    {
        if (!isTyping)
        {
            ShowNextDialog();

            buttonManager.gameObject.SetActive(false);
            isClicked = true;

            StartCoroutine(Wait());

        }
    }

    public void nextDiyalog()
    {
        ShowNextDialog();

        buttonManager.gameObject.SetActive(false);
        isClicked = true;

        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {

        float x = GetTypeingTime(1);
        yield return new WaitForSeconds(x);
        npcManager = FindAnyObjectByType<NpcManager>();
        ShowNextDialog();
        isDialogOver = true;
    }

    private IEnumerator Sequence()
    {
        if (!isIntro)
        {
            float x = GetTypeingTime(0);
            yield return new WaitForSeconds(x);

            /*Text buttonText = buttonManager.GetComponentInChildren<Text>();
            buttonText.text = npcManager.GetDialog(1);*/
            buttonManager.gameObject.SetActive(true);
            ButtonText.text = npcManager.GetDialog(1);
        }

        
    }

    public float GetTypeingTime(int dialogIndex)
    {
        float typeTotalTime = typingSpeed * (npcManager.GetDialog(dialogIndex)).Length;
        return typeTotalTime;
    }

    public void ShowNextDialog()
    {
        npcManager = FindAnyObjectByType<NpcManager>();
        StartCoroutine(TypeText(npcManager.GetDialog(dialogIndex)));
        dialogIndex++;
        if (!isIntro && (dialogIndex == 1))
        {
            StartCoroutine(Sequence());
        }
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

    public void ClearText()
    {
        textBubble.text = "";
    }

    public void ClearDialogIndex()
    {
        dialogIndex = 0;
    }

}
