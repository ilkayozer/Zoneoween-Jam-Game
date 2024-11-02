using System.Collections;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;

    public float doorMoveDistance = 2.0f; // Adjust the distance to move each door
    public float doorSpeed = 1.0f; // Adjust the speed of the door movement

    private Vector3 leftDoorClosedPos;
    private Vector3 leftDoorOpenPos;
    private Vector3 rightDoorClosedPos;
    private Vector3 rightDoorOpenPos;

    private bool isOpening = false;
    private float lerpTime = 0f;

    void Start()
    {
        // Set the closed positions to the doors' initial positions
        leftDoorClosedPos = leftDoor.transform.position;
        rightDoorClosedPos = rightDoor.transform.position;

        // Calculate the target open positions based on the door width
        leftDoorOpenPos = leftDoorClosedPos + Vector3.left * doorMoveDistance;
        rightDoorOpenPos = rightDoorClosedPos + Vector3.right * doorMoveDistance;
    }

    void Update()
    {
        if (isOpening)
        {
            lerpTime += Time.deltaTime * doorSpeed;
            leftDoor.transform.position = Vector3.Lerp(leftDoorClosedPos, leftDoorOpenPos, lerpTime);
            rightDoor.transform.position = Vector3.Lerp(rightDoorClosedPos, rightDoorOpenPos, lerpTime);

            if (lerpTime >= 1f)
            {
                lerpTime = 0f;
                isOpening = false;
            }
        }
    }

    public void Open()
    {
        isOpening = true;
    }

    public void Close()
    {
        isOpening = false;
        leftDoor.transform.position = leftDoorClosedPos;
        rightDoor.transform.position = rightDoorClosedPos;
    }
}
