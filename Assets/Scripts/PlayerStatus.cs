using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int chance = 3;
    public int level = 0;

    public NpcManager npcManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LetInChar()
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
    }

    void DenyChar()
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
    }

}
