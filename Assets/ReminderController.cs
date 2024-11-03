using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReminderController : MonoBehaviour
{
    public GameObject reminderSheet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReminderSheetOpen()
    {
        reminderSheet.SetActive(true);
    }

    public void ReminderSheetCloser()
    {
        reminderSheet.SetActive(false);
    }
}
