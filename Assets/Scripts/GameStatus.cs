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
    [SerializeField] private Text scoreText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void IncreaseScore()
    {
        score += scorePerBlock;
        scoreText.text = "SCORE: " + score.ToString();
    }
}
