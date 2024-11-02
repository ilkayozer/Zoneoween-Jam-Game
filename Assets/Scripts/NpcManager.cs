using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string npcName = "Albino Zenci";
    public string[] dialogs = { "Sa benim ad�m ", "Beni al", "t�k a�ko <3" };
    public int floor;

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
                return dialogs[index] += npcName + "\n\n";
            }
            return dialogs[index] + "\n\n";
        return string.Empty;
    }
}
