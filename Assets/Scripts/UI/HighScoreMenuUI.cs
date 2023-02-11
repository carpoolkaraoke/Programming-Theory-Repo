using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenuUI : MonoBehaviour
{
    [Header("UI Controls")]
    [SerializeField] private TextMeshProUGUI highScoreNamesText;
    [SerializeField] private TextMeshProUGUI highScoresText;
    [SerializeField] private Button titleMenuButton;

    private Action titleMenu;
    private Action<TextMeshProUGUI, TextMeshProUGUI> reportHighScores;
    
    private void OnEnable()
    {
        titleMenuButton.onClick.AddListener(TitleMenuButton_Clicked);

        reportHighScores?.Invoke(highScoreNamesText, highScoresText);
    }

    private void OnDisable()
    {
        titleMenuButton.onClick.RemoveListener(TitleMenuButton_Clicked);
    }

    public void Init(Action titleMenu, Action<TextMeshProUGUI, TextMeshProUGUI> reportHighScores)
    {
        this.titleMenu = titleMenu;
        this.reportHighScores = reportHighScores;
    }

    private void TitleMenuButton_Clicked()
    {
        titleMenu();
    }    
}
