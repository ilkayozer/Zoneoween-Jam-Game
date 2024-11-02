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
        npcManager = FindAnyObjectByType<NpcManager>();

        //if (npcObject != null)
        //    npcManager = npcObject.GetComponent<NpcManager>();
        buttonManager.onClick.AddListener(OnBottomTextClicked);

        if (!isIntro)
        {
            StartCoroutine(Sequence());
        }
    }

    public void OnBottomTextClicked()
    {
        if (!isTyping)
        {
            ShowNextDialog();

            Destroy(buttonManager.gameObject);
            isClicked = true;

            //StartCoroutine(Wait(waitTime));

        }
    }

    private IEnumerator Sequence()
    {
        Debug.Log(isIntro);
        if (!isIntro)
        {
            float x = GetTypeingTime(0) + 2.5f;
            yield return new WaitForSeconds(x);

            buttonManager.gameObject.SetActive(true);
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

}
