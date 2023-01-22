using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public void StartGameButton_Clicked()
    {
        GameManager.instance.StartGame();
    }

    public void MainMenuButton_Clicked()
    {
        GameManager.instance.TitleScreen();
    }
}
