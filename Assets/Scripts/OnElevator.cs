using System.Collections;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private Vector3 targetPosition = new Vector3(-6, -2, 0); // Hardcoded to ensure it moves to the correct position
    public float moveDuration = 3.0f; // Time in seconds for the movement to complete

    void Start()
    {
        // Set the capsule's initial position to (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);

        // Start the movement coroutine to move to the target position
        StartCoroutine(MoveToPosition(targetPosition, moveDuration));
    }

    private IEnumerator MoveToPosition(Vector3 target, float duration)
    {
        Vector3 start = transform.position;
        float elapsed = 0;

        while (elapsed < duration)
        {
            // Interpolate position from start to target based on elapsed time
            transform.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the object ends up exactly at the target position
        transform.position = target;
        Debug.Log("Final position: " + transform.position); // Log final position to confirm
    }
}

