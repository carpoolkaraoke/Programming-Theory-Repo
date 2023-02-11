using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;

    private Action mainMenu;

    private void OnEnable()
    {
        mainMenuButton.onClick.AddListener(MainMenuButton_Clicked);
    }

    private void OnDisable()
    {
        mainMenuButton.onClick.RemoveListener(MainMenuButton_Clicked);
    }

    public void Init(Action mainMenu)
    {
        this.mainMenu = mainMenu;
    }

    private void MainMenuButton_Clicked()
    {
        mainMenu();
    }
}
