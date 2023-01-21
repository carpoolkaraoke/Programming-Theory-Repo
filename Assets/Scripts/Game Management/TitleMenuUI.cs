using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleMenuUI : MonoBehaviour
{
    [SerializeField] private HighScoreMenuUI highScoreMenu;

    private void Start()
    {
        //**************************
        // Need to read data...
    }



    private void ReadData()
    {

    }

    private void SaveData()
    {

    }

    public void HighScoresMenu()
    {
        highScoreMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        //*****************************
        // Need to save data...


#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        return;
#endif

        Application.Quit();
    }
}
