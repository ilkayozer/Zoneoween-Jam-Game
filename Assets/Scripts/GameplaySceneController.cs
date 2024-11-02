using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySceneController : MonoBehaviour
{
    private TextManager textManager;
    private PlayerStatus PlayerStats;

    // Start is called before the first frame update
    void Start()
    {
        textManager = FindAnyObjectByType<TextManager>();
        PlayerStats = FindAnyObjectByType<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    /*private IEnumerator wait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }*/
}
