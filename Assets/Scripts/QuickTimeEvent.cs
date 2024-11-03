using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuickTimeEvent : MonoBehaviour
{
    public GameObject qtePanel; // Reference to the QTE Panel
    public TMP_Text targetWordText; // Text component for the target word
    public TMP_InputField playerInputField; // Input field for player input
    public TMP_Text timerText; // Text component for the timer display
    public TMP_Text gameOverText; // Game over text to display when out of chances


    private string targetWord; // Current target word
    public float timeLimit = 5f; // Time limit in seconds for each word
    private float timer; // Countdown timer
    private bool isQTEActive = false; // To check if QTE is active

    public AudioSource qteSound;

    public bool isButtonShowed = false;

    private string[] sentences = {
        "God save me",
        "I pray to you",
        "I will do better",
        "I regret it all",
        "Never again",
        "Help me believe"
    };

    private PlayerStatus playerStatus; // Reference to the PlayerStatus script

    void Start()
    {
        qtePanel.SetActive(false); // Hide QTE panel initially
        gameOverText.gameObject.SetActive(false); // Hide Game Over text initially
        playerInputField.onEndEdit.AddListener(CheckPlayerInput); // Check input when player submits
        playerStatus = FindObjectOfType<PlayerStatus>(); // Find the PlayerStatus component
    }

    public void StartQuickTimeEvent()
    {
        
        if (playerStatus.chance >= 1) // Only start QTE if more than 1 chance is left
        {

            qtePanel.SetActive(true); // Show the QTE panel
            gameOverText.gameObject.SetActive(false); // Hide Game Over text in case it was shown before
            StartNewSentence(); // Display a new sentence
        }
        else
        {
            ShowGameOver(); // Show game over if only 1 chance is left
        }
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

        isButtonShowed = false;
        
    }

    private void FailQTE()
    {
        isQTEActive = false;
        //playerStatus.chance -= 1; // Deduct one chance
        timerText.text = "Time Left: 0.0"; // Show time is up
        qtePanel.SetActive(false); // Hide the QTE panel on failure
        Debug.Log("Failed! Game Over.");

        SceneManager.LoadScene(3);

        isButtonShowed = false;
    }

    private void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true); // Display the Game Over text
    }
}






