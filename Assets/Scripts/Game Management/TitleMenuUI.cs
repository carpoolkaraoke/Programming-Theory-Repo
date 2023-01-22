using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenuUI : MonoBehaviour
{
    [SerializeField] private HowToPlayUI howToPlayMenu;
    [SerializeField] private HighScoreMenuUI highScoreMenu;

    public void StartGameButton_Clicked()
    {
        GameManager.instance.StartGame();
    }

    public void HowToPlayButton_Clicked()
    {
        howToPlayMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void HighScoresButton_Clicked()
    {
        highScoreMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitGameButton_Clicked()
    {
        GameManager.instance.ExitGame();
    }
}
