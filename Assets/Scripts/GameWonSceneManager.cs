using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonSceneManager : MonoBehaviour
{
    public DoorMovement doorManager;
    // Start is called before the first frame update
    void Start()
    {
        doorManager.Open();

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
