using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReminderController : MonoBehaviour
{
    

    public GameObject reminderOpenButton;
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
        reminderOpenButton.SetActive(false);
    }

    public void ReminderSheetCloser()
    {
        reminderSheet.SetActive(false);
        reminderOpenButton.SetActive(true);
        
    }
}
