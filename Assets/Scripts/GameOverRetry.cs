using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverRetry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
