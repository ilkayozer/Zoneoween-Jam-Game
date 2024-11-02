using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FATutorialManager : MonoBehaviour
{

    public GameObject fallenAngel;
    public DoorMovement doorMovement;
    public TextManager textManager;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(doorWaiting());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator doorWaiting()
    {
        doorMovement.Open();
        yield return new WaitForSeconds(2.2f);
        textManager.ShowNextDialog();

    }

}
