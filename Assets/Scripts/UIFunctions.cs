using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour {

    [SerializeField]
    private int score;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    public bool gameStarted = false;
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button shopButton;
    [SerializeField]
    private Button leaderboardButton;
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Button tapToPlayButton;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button homeButton;
    [SerializeField]
    private Text endScoreText;
    [SerializeField]
    private Text endBestScoreText;


    // Use this for initialization
    void Start () {
        Debug.Log(PlayerPrefs.GetInt("Score"));
        InvokeRepeating("UpdateScore", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScore();

    }

    public void SettingsFunctions()
    {

    }

    public void ShopFunctions()
    {

    }
    public void PlayGame()
    {
        scoreText.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(false);
        leaderboardButton.gameObject.SetActive(false);
        shopButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        tapToPlayButton.gameObject.SetActive(false);

        gameStarted = true;
    }
    private void UpdateScore()
    {
        if (gameStarted == true)
        {
            score++;
            scoreText.text = "" + score;
        }        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("RestartScene");
    }
    public void HomeFunction()
    {
        SceneManager.LoadScene("MobileGameLevel");
    }

    public void GameEnded()
    {
        if (PlayerPrefs.GetInt("Score") < score)
        {
            PlayerPrefs.SetInt("Score", score);
        }

        endScoreText.text = "Score: " + score;
        endBestScoreText.text = "Best score: " + PlayerPrefs.GetInt("Score");
        endScoreText.gameObject.SetActive(true);
        endBestScoreText.gameObject.SetActive(true);

        scoreText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        homeButton.gameObject.SetActive(true);
        gameStarted = false;
        PlayerPrefs.Save();
    }

}
