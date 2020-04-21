using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [Range(.1f, 10f)][SerializeField] private float gameSpeed = 1f;
    [SerializeField] int score;
    [SerializeField] int scorePerBlock = 10;
    [SerializeField] private int highscore;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    void Awake()
    {
        var gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        highScoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHighScore();
        Time.timeScale = gameSpeed;
    }

    public void IncreaseScore()
    {
        score += scorePerBlock;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void ResetGame()
    {
        score = 0;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void CheckHighScore()
    {
        if (score > highscore)
        {
            highscore = score;
            highScoreText.text = "HIGHSCORE: " + highscore.ToString();
        }
    }
}
