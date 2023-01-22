using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayUI : MonoBehaviour
{
    [SerializeField] private TitleMenuUI titleMenu;

    public void TitleMenuButton_Clicked()
    {
        titleMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
