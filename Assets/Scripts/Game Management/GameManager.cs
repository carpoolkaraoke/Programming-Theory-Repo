using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private SphereController cometPrefab;
    [SerializeField] private SphereController bumperPrefab;


    public static GameManager instance;

    private GameOverUI gameOverMenu;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /*private void Start()
    {
        gameOverMenu.gameObject.SetActive(false);
    }*/

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            //**************************************
            gameOverMenu = FindObjectOfType<GameOverUI>();
            gameOverMenu.gameObject.SetActive(false);

            StartCoroutine(CountdownTime());

            for (int i = 0; i < 5; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-17f, 17f), Random.Range(-9f, 9));
                Instantiate(cometPrefab, spawnPos, Quaternion.identity);

                spawnPos = new Vector3(Random.Range(-17f, 17f), Random.Range(-9f, 9));
                Instantiate(bumperPrefab, spawnPos, Quaternion.identity);
            }
        }
    }

    private IEnumerator CountdownTime()
    {
        ScoreTimeUI scoreTimeUI = FindObjectOfType<ScoreTimeUI>();

        int timeRemaining = 10;
        while (timeRemaining >= 0)
        {
            scoreTimeUI.UpdateTime(timeRemaining);
            timeRemaining -= 1;

            yield return new WaitForSeconds(1);            
        }

        GameOver();
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void GameOver()
    {
        gameOverMenu.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        //******************************
        // Need to save high score data...

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif

        Application.Quit();
    }
}
