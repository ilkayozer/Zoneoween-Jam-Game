using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySceneController : MonoBehaviour
{
    private TextManager TextManager;
    private PlayerStatus PlayerStats;
    private CharSelect Spawner;
    private DoorMovement DoorManager;

    // Start is called before the first frame update
    void Start()
    {
        DoorManager = FindAnyObjectByType<DoorMovement>();
        Spawner = FindAnyObjectByType<CharSelect>();
        TextManager = FindAnyObjectByType<TextManager>();
        PlayerStats = FindAnyObjectByType<PlayerStatus>();

        StartCoroutine(Routine());
        Spawner.SelectRandomChar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Routine()
    {
        yield return new WaitForSeconds(1f);
        DoorManager.Open();
        yield return new WaitForSeconds(2f);

        TextManager.ShowNextDialog();
        yield return new WaitForSeconds(TextManager.GetTypeingTime(2));
        

        yield return new WaitForSeconds(TextManager.GetTypeingTime(0));

    }

    private IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}
