using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControllerScript : MonoBehaviour
{
    public Text highscoreText;
    public void play()
    {
        SceneManager.LoadScene("Gameplay");
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highscoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        }
        else
        {
            highscoreText.text = "High Score: " + 0;
        }
        
    }
}
