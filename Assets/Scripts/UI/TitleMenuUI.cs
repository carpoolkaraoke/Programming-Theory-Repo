using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMenuUI : MonoBehaviour
{
    // *** Encapsulation ***
    [Header("UI Components")]
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button howToPlayButton;
    [SerializeField] private Button highScoresButton;
    [SerializeField] private Button exitGameButton;

    // *** Encapsulation ***
    [Header("In Scene Game Objects")]
    //[SerializeField] private HowToPlayUI howToPlayMenu;
    //[SerializeField] private HighScoreMenuUI highScoreMenu;

    // *** Encapsulation ***
    private Action startGame;
    private Action howToPlay;
    private Action highScores;
    private Action exitGame;

    private void OnEnable()
    {
        startGameButton.onClick.AddListener(StartGameButton_Clicked);
        howToPlayButton.onClick.AddListener(HowToPlayButton_Clicked);
        highScoresButton.onClick.AddListener(HighScoresButton_Clicked);
        exitGameButton.onClick.AddListener(ExitGameButton_Clicked);
    }

    private void OnDisable()
    {
        startGameButton.onClick.RemoveListener(StartGameButton_Clicked);
        howToPlayButton.onClick.RemoveListener(HowToPlayButton_Clicked);
        highScoresButton.onClick.RemoveListener(HighScoresButton_Clicked);
        exitGameButton.onClick.RemoveListener(ExitGameButton_Clicked);
    }

    public void Init(Action startGame, Action howToPlay, Action highScores, Action exitGame)
    {
        this.startGame = startGame;
        this.howToPlay = howToPlay;
        this.highScores = highScores;
        this.exitGame = exitGame;
    }

    private void StartGameButton_Clicked()
    {
        startGame();
    }

    private void HowToPlayButton_Clicked()
    {
        howToPlay();
    }

    private void HighScoresButton_Clicked()
    {
        highScores();
    }

    private void ExitGameButton_Clicked()
    {
        exitGame();
    }
}
