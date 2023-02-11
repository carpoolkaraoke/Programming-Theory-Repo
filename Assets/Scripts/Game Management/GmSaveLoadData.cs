using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GmSaveLoadData
{
    public void SaveData(HighScore[] highScores)
    {
        try
        {
            var saveDataJsonFormat = new SaveDataJsonFormat();
            //saveDataJsonFormat.names = new string[GmHighScores.highScoresTableLength];
            //saveDataJsonFormat.scores = new int[GmHighScores.highScoresTableLength];
            for (int i = 0; i < GmHighScores.highScoresTableLength; i++)
            {
                saveDataJsonFormat.names[i] = highScores[i].name;
                saveDataJsonFormat.scores[i] = highScores[i].score;
            }

            string json = JsonUtility.ToJson(saveDataJsonFormat);
            string path = Application.persistentDataPath + "/savefile.json";
            File.WriteAllText(path, json);
        }
        catch
        {
            Debug.Log("Error: Could Not Save High Scores.");
        }
    }

    public void LoadData(Action<HighScore[]> setHighScores)
    {
        try
        {
            string path = Application.persistentDataPath + "/savefile.json";
            string json = File.ReadAllText(path);
            var saveDataJsonFormat = JsonUtility.FromJson<SaveDataJsonFormat>(json);

            var highScores = new HighScore[GmHighScores.highScoresTableLength];
            for (int i = 0; i < GmHighScores.highScoresTableLength; i++)
            {
                highScores[i] = new HighScore(saveDataJsonFormat.names[i], saveDataJsonFormat.scores[i]);
            }

            setHighScores(highScores);
        }
        catch
        {
            Debug.Log("Error: Could Not Load High Scores.");
        }
    }

    class SaveDataJsonFormat
    {
        public string[] names;
        public int[] scores;

        public SaveDataJsonFormat()
        {
            names = new string[GmHighScores.highScoresTableLength];
            scores = new int[GmHighScores.highScoresTableLength];
        }
    }
}
