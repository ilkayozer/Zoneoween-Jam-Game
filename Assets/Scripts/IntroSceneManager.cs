using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneManager : MonoBehaviour
{
    public GameObject Jesus;

    private float duration;
    private DoorMovement doorManager;
    private TextManager textManager;
    // Start is called before the first frame update
    void Start()
    {
        doorManager = FindAnyObjectByType<DoorMovement>();
        textManager = FindAnyObjectByType<TextManager>();

        //Door waiting time
        //float duration = doorManager.doorMoveDistance * doorManager.doorSpeed;
        StartCoroutine(StartSeq(duration));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator StartSeq(float duration)
    {
        doorManager.Open();
        duration = doorManager.doorMoveDistance * doorManager.doorSpeed;

        yield return new WaitForSeconds(duration);
        textManager.ShowNextDialog();

        while (!textManager.isClicked)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(textManager.GetTypeingTime(1));

        textManager.ShowNextDialog();

        yield return new WaitForSeconds(textManager.GetTypeingTime(2));

        doorManager.Close();
        //yield return new WaitForSeconds(duration);

        //textManager.ShowNextDialog();
    }

    /*private IEnumerator Wait(float duration = 2f)
    {
        yield return new WaitForSeconds(duration);

        textManager.ShowNextDialog();
    }*/
}
