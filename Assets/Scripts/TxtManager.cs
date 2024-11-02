using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Required to use Button component

public class TextBubbleManager : MonoBehaviour
{
    public GameObject npcObject;
    public TMP_Text textBubble;
    public Button bottomText;
    public float typingSpeed = 0.05f;
    public float waitTime = 2f;

    private NpcManager npcManager;
    private int dialogIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        if (npcObject != null)
            npcManager = npcObject.GetComponent<NpcManager>();
        bottomText.onClick.AddListener(OnBottomTextClicked);

        ShowNextDialog();
    }

    public void OnBottomTextClicked()
    {
        if (!isTyping)
        {
            dialogIndex++;
            ShowNextDialog();

            Destroy(bottomText.gameObject);

            StartCoroutine(Wait(waitTime));

        }
    }

    private void ShowNextDialog()
    {
            StartCoroutine(TypeText(npcManager.GetDialog(dialogIndex)));
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dialogIndex++;
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
