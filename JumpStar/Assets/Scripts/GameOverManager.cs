using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
	public static GameOverManager instance;

	private GameObject gameOverPanel;
	
	private Button refreshButton, backButton;

	private GameObject inGameScore;
	public Text finalScore;

	void Awake()
	{
		MakeInstance();
		InitializeVariables();
	}

	void MakeInstance()
	{
		if (instance == null)
			instance = this;
	}

	public void GameOverShowPanel()
	{
		inGameScore.SetActive(false);
		gameOverPanel.SetActive(true);
		finalScore.text = "Score\n" + ScoreManagerScript.instance.getScore();

	}

	void InitializeVariables()
	{
		gameOverPanel = GameObject.Find("Game Over Panel Holder");

		refreshButton = GameObject.Find("Refresh Button").GetComponent<Button>();
		backButton = GameObject.Find("Back Button").GetComponent<Button>();

		refreshButton.onClick.AddListener(() => PlayAgain());
		backButton.onClick.AddListener(() => BackToMenu());

		inGameScore = GameObject.Find("InGameScore");
		//finalScore = GameObject.Find("Final Score").GetComponent<Text>();

		gameOverPanel.SetActive(false);
	}

	public void PlayAgain()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void BackToMenu()
	{
		Application.LoadLevel("MainMenu");
	}

}
