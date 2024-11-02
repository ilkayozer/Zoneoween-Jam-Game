using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuickTimeEvent : MonoBehaviour
{
    public GameObject qtePanel; // Reference to the QTE Panel
    public TMP_Text targetWordText; // Text component for the target word
    public TMP_InputField playerInputField; // Input field for player input
    public TMP_Text timerText; // Text component for the timer display

    private string targetWord; // Current target word
    private float timeLimit = 3.5f; // Time limit in seconds for each word
    private float timer; // Countdown timer
    private bool isQTEActive = false; // To check if QTE is active

    private string[] sentences = {
        "God save me",
        "I pray to you",
        "I will do better",
        "I regret it all",
        "Never again",
        "Help me believe"
    };

    void Start()
    {
        qtePanel.SetActive(false); // Hide QTE panel initially
        playerInputField.onEndEdit.AddListener(CheckPlayerInput); // Check input when player submits
    }

    public void StartQuickTimeEvent()
    {
        qtePanel.SetActive(true); // Show the QTE panel
        StartNewSentence(); // Display a new sentence
    }

    private void StartNewSentence()
    {
        // Pick a random sentence
        targetWord = sentences[Random.Range(0, sentences.Length)];
        targetWordText.text = "Type: " + targetWord;

        // Reset input and timer
        playerInputField.text = "";
        playerInputField.ActivateInputField();
        timer = timeLimit;
        isQTEActive = true;
    }

    void Update()
    {
        if (isQTEActive)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time Left: " + timer.ToString("F1"); // Display remaining time

            // Check if time is up
            if (timer <= 0)
            {
                FailQTE(); // Player failed to type within the time limit
            }
        }
    }

    public void CheckPlayerInput(string input)
    {
        if (isQTEActive)
        {
            if (input.Equals(targetWord, System.StringComparison.OrdinalIgnoreCase))
            {
                SucceedQTE();
            }
            else
            {
                FailQTE();
            }
        }
    }

    private void SucceedQTE()
    {
        isQTEActive = false;
        qtePanel.SetActive(false); // Hide the QTE panel on success
        Debug.Log("Success!");
    }

    private void FailQTE()
    {
        isQTEActive = false;
        timerText.text = "Time Left: 0.0"; // Show time is up
        qtePanel.SetActive(false); // Hide the QTE panel on failure
        Debug.Log("Failed! Game Over.");
    }
}





