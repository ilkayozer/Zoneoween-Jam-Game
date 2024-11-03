using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int chance = 3;
    public int level = 0;
    public bool isDenied = false;
    public bool isLetIn = false;

    public NpcManager npcManager;
    public TextManager textManager;

    public Button letInButton;
    public Button denyButton;

    public SpriteRenderer charSpriteRenderer;
    public Sprite charSprite;

    // Start is called before the first frame update
    void Start()
    {
        textManager = FindAnyObjectByType<TextManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(textManager.isDialogOver)
        {
            buttonActives();
        }
    
    }

    void buttonActives()
    {
        letInButton.gameObject.SetActive(true);
        denyButton.gameObject.SetActive(true);
    }

    void buttonDeactives()
    {
        letInButton.gameObject.SetActive(false);
        denyButton.gameObject.SetActive(false);
    }

    public void LetInChar()
    {
        npcManager = FindAnyObjectByType<NpcManager>();
        if (npcManager.isEvil)
        {
            chance -= 1;
        }
        else
        {
            level += 1;
        }
        textManager.isDialogOver = false;
        isLetIn = true;
        buttonDeactives();
    }

    public void DenyChar()
    {
        npcManager = FindAnyObjectByType<NpcManager>();
        if(!npcManager.isEvil)
        {
            chance -= 1;
        }
        else
        {
            level += 1;
        }
        textManager.isDialogOver = false;
        isDenied = true;
        buttonDeactives();
    }

}
