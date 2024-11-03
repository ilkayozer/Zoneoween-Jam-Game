using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string npcName;
    public string[] dialogs;
    public int floor;

    public bool isEvil;

    public Sprite elevatorInSprite;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetDialog(int index)
    {
        if (index < dialogs.Length)
            if (index == 0)
            {
                return dialogs[index] + "\n\n";
            }
            return dialogs[index] + "\n\n";
        
    }
}
