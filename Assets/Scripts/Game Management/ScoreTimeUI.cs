using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTimeUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;

    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateTime(int time)
    {
        timeText.text = "TIME: " + time;
    }

}
