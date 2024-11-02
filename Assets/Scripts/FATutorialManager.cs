using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FATutorialManager : MonoBehaviour
{

    public GameObject fallenAngel;
    public DoorMovement doorMovement;


    // Start is called before the first frame update
    void Start()
    {
        Object.Instantiate(fallenAngel, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
