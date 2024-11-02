using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour
{
    public List<GameObject> charPrefabs; // Assign your character prefabs in the Inspector

    private GameObject currentCharacter; // Track the currently displayed character

    void Update()
    {
        // Trigger a new selection when pressing the space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectRandomChar();
        }
    }

    public void SelectRandomChar()
    {
        // If there is already a character displayed, destroy it
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }

        if (charPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, charPrefabs.Count);
            GameObject selectedCharPrefab = charPrefabs[randomIndex];

            // Define a spawn position in the center of the screen
            Vector3 spawnPosition = new Vector3(0, 0, 0);

            // Instantiate the selected character at the spawn position
            currentCharacter = Instantiate(selectedCharPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Instantiated Char: " + currentCharacter.name);

            // Remove the selected prefab from the list so it can't be chosen again
            charPrefabs.RemoveAt(randomIndex);
        }
        else
        {
            Debug.Log("No characters left to select.");
        }
    }
}

