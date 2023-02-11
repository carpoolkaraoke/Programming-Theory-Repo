using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmGameplay
{
    public Action<int> updateScore;
    public Action<int> updateTime;

    // *** Encapsulation ***
    private int blueCometPoints = 100;
    private int redCometPoints = -50;
    private readonly int startTime = 60;
    private int score;

    public bool IsPaused { get; private set; }
    public bool IsGameOver { get; private set; }

    public IEnumerator StartNewGame(ScoreTimeUI scoreTimeUI, Action<int> gameOver)
    {
        score = 0;
        IsPaused = false;
        IsGameOver = false;
        Time.timeScale = 1;
        scoreTimeUI.UpdateScore(score);

        int time = startTime;
        while (time >= 0)
        {
            scoreTimeUI.UpdateTime(time);
            time -= 1;

            yield return new WaitForSeconds(1);
        }

        PauseUnpause();
        IsGameOver = true;
        gameOver(score);
    }

    public void IncreaseScore(Collision collision, ScoreTimeUI scoreTimeUI)
    {
        if (collision.gameObject.CompareTag("Blue Comet"))
        {
            score += blueCometPoints;
        }
        else if (collision.gameObject.CompareTag("Red Comet"))
        {
            score += redCometPoints;
        }

        if (score < 0)
        {
            score = 0;
        }

        scoreTimeUI.UpdateScore(score);
    }

    public int GetScore()
    {
        return score;
    }

    public void PauseUnpause()
    {
        if (!IsGameOver)
        {
            if (IsPaused)
            {
                IsPaused = false;
                Time.timeScale = 1;
            }
            else
            {
                IsPaused = true;
                Time.timeScale = 0;
            }
        }
    }
}
