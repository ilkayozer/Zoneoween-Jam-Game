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
    private bool isClosing = false;
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
                lerpTime = 1f; // Ensure it doesn’t exceed 1
                isOpening = false;
            }
        }
        else if (isClosing)
        {
            lerpTime -= Time.deltaTime * doorSpeed;
            leftDoor.transform.position = Vector3.Lerp(leftDoorClosedPos, leftDoorOpenPos, lerpTime);
            rightDoor.transform.position = Vector3.Lerp(rightDoorClosedPos, rightDoorOpenPos, lerpTime);

            if (lerpTime <= 0f)
            {
                lerpTime = 0f; // Ensure it doesn’t go below 0
                isClosing = false;
            }
        }
    }
    public IEnumerator WaitOpen()
    {
        isOpening = true;
        isClosing = false; // Stop closing if it’s in progress
        lerpTime = 0f; // Reset lerpTime for opening
        yield return new WaitForSeconds(doorMoveDistance * doorSpeed);
    }

    public void Open()
    {
        isOpening = true;
        isClosing = false; // Stop closing if it’s in progress
        lerpTime = 0f; // Reset lerpTime for opening
    }

    public void Close()
    {
        isClosing = true;
        isOpening = false; // Stop opening if it’s in progress
        lerpTime = 1f; // Set lerpTime to 1 to start from the open position
    }
}
