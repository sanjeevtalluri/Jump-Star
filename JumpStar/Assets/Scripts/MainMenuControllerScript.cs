using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerScript : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
