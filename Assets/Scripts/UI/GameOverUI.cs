using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button highScoresButton;
    [SerializeField] private Button mainMenuButton;

    private Action startGame;
    private Action highScoresMenu;
    private Action mainMenu;
    private Action<HighScore> updateHighScores;
    private Func<int> score;

    private void OnEnable()
    {
        startGameButton.onClick.AddListener(StartGameButton_Clicked);
        highScoresButton.onClick.AddListener(HighScoresButton_Clicked);
        mainMenuButton.onClick.AddListener(MainMenuButton_Clicked);
    }

    private void OnDisable()
    {
        startGameButton.onClick.RemoveListener(StartGameButton_Clicked);
        highScoresButton.onClick.RemoveListener(HighScoresButton_Clicked);
        mainMenuButton.onClick.RemoveListener(MainMenuButton_Clicked);
    }

    public void Init(Action startGame, Action highScoresMenu, Action mainMenu, Action<HighScore> updateHighScores, Func<int> score)
    {
        this.startGame = startGame;
        this.highScoresMenu = highScoresMenu;
        this.mainMenu = mainMenu;
        this.updateHighScores = updateHighScores;
        this.score = score;
    }

    private void StartGameButton_Clicked()
    {
        if (nameInputField.gameObject.activeSelf)
        {
            updateHighScores(new HighScore(nameInputField.text, score()));
        }

        startGame();
    }

    private void HighScoresButton_Clicked()
    {
        if (nameInputField.gameObject.activeSelf)
        {
            updateHighScores(new HighScore(nameInputField.text, score()));
        }

        highScoresMenu();
    }

    private void MainMenuButton_Clicked()
    {
        if (nameInputField.gameObject.activeSelf)
        {
            updateHighScores(new HighScore(nameInputField.text, score()));
        }

        mainMenu();
    }

    public void ShowHighScoreText()
    {
        highScoreText.gameObject.SetActive(true);
    }

    public void HideHighScoreText()
    {
        highScoreText.gameObject.SetActive(false);
    }

    public void ShowNameInputField()
    {
        nameInputField.gameObject.SetActive(true);
    }

    public void HideNameInputField()
    {
        nameInputField.gameObject.SetActive(false);
    }
}
