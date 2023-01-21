using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreMenuUI : MonoBehaviour
{
    [SerializeField] private TitleMenuUI titleMenu;

    public void TitleMenu()
    {
        titleMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
