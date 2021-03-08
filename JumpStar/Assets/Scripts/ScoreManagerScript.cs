using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public static ScoreManagerScript instance;
    public Text inGameText;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        MakeInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void IncrementScore()
    {
        score++;
        inGameText.text = ""+score;
    }
    public int getScore()
    {
        return score;
    }
}
