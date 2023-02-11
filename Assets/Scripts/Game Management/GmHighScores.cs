using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class GmHighScores
{
    public static readonly int highScoresTableLength = 5;

    // *** Encapsulation ***
    private HighScore[] highScores;

    public HighScore[] HighScores
    {
        get
        {
            HighScore[] highScoresCopy = new HighScore[highScoresTableLength];
            for (int i = 0; i < highScoresCopy.Length; i++)
            {
                string name = highScores[i].name;
                int score = highScores[i].score;
                highScoresCopy[i] = new HighScore(name, score);
            }

            return highScoresCopy;
        }
    }

    public void SetHighScores(HighScore[] highScores)
    {
        this.highScores = highScores;
    }

    public void ReportHighScores(TextMeshProUGUI highScoreNamesText, TextMeshProUGUI highScoresText)
    {
        var sbNames = new StringBuilder();
        var sbScores = new StringBuilder();
        for (int i = 0; i < highScoresTableLength; i++)
        {
            sbNames.Append($"{i + 1}.  {highScores[i].name}\n");
            sbScores.Append(highScores[i].score + "\n");
        }

        highScoreNamesText.text = sbNames.ToString();
        highScoresText.text = sbScores.ToString();
    }

    public bool IsHighScore(int score)
    {
        bool isHighScore = false;
        foreach (HighScore highScore in highScores)
        {
            if (score > highScore.score)
            {
                isHighScore = true;

                break;
            }
        }

        return isHighScore;
    }

    public void UpdateHighScores(HighScore highScore)
    {
        int index = -1;
        for (int i = 0; i < highScoresTableLength; i++)
        {
            if (highScore.score > highScores[i].score)
            {
                index = i;

                break;
            }
        }

        if (index != -1)
        {
            var highScoresList = new List<HighScore>(highScores);
            highScoresList.Insert(index, highScore);
            highScoresList.RemoveAt(highScoresList.Count - 1);

            highScores = highScoresList.ToArray();
        }
    }    
}
