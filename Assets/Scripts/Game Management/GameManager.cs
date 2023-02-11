using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // *** Singleton Pattern ***
    public static GameManager Instance;

    private GmSaveLoadData gmSaveLoadData;
    private GmHighScores gmHighScores;
    private GmGameplay gmGameplay;

    // *** Encapsulation ***
    [Header("Prefabs")]
    [SerializeField] private BumperController bumperPrefab;
    [SerializeField] private CometController blueCometPrefab;
    [SerializeField] private CometController redCometPrefab;    

    // *** Encapsulation ***
    private TitleMenuUI titleMenuUI;
    private HowToPlayUI howToPlayUI;
    private HighScoreMenuUI highScoresUI;
    private ScoreTimeUI scoreTimeUI;
    private GameOverUI gameOverUI;


    #region MonoBehaviour

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);

            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
        Init();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gmGameplay.PauseUnpause();
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    #endregion MonoBehaviour

    private void Init()
    {
        gmHighScores = new GmHighScores();
        gmSaveLoadData = new GmSaveLoadData();
        gmGameplay = new GmGameplay();

        gmSaveLoadData.LoadData(gmHighScores.SetHighScores);
    }

    public void IncreaseScore(Collision collision)
    {
        gmGameplay.IncreaseScore(collision, scoreTimeUI);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            titleMenuUI = FindObjectOfType<TitleMenuUI>();
            titleMenuUI.Init(StartGame, HowToPlayFromTitleMenu, HighScoresFromTitleMenu, ExitGame);

            howToPlayUI = FindObjectOfType<HowToPlayUI>();
            howToPlayUI.Init(TitleMenuFromHowToPlay);
            howToPlayUI.gameObject.SetActive(false);

            highScoresUI = FindObjectOfType<HighScoreMenuUI>();
            highScoresUI.Init(TitleMenuFromHighScores, gmHighScores.ReportHighScores);
            highScoresUI.gameObject.SetActive(false);
        }
        else if (scene.buildIndex == 1)
        {
            gameOverUI = FindObjectOfType<GameOverUI>();
            gameOverUI.Init(StartGame, HighScoresFromGameOver, MainMenuFromGameOver, gmHighScores.UpdateHighScores, gmGameplay.GetScore);
            gameOverUI.gameObject.SetActive(false);

            highScoresUI = FindObjectOfType<HighScoreMenuUI>();
            highScoresUI.Init(GameOverFromHighScores, gmHighScores.ReportHighScores);
            highScoresUI.gameObject.SetActive(false);

            scoreTimeUI = FindObjectOfType<ScoreTimeUI>();

            StartCoroutine(gmGameplay.StartNewGame(scoreTimeUI, GameOver));
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void HowToPlayFromTitleMenu()
    {
        howToPlayUI.gameObject.SetActive(true);
        titleMenuUI.gameObject.SetActive(false);
    }

    private void TitleMenuFromHowToPlay()
    {
        titleMenuUI.gameObject.SetActive(true);
        howToPlayUI.gameObject.SetActive(false);
    }

    private void HighScoresFromTitleMenu()
    {
        highScoresUI.gameObject.SetActive(true);
        titleMenuUI.gameObject.SetActive(false);
    }

    private void TitleMenuFromHighScores()
    {
        titleMenuUI.gameObject.SetActive(true);
        highScoresUI.gameObject.SetActive(false);
    }

    private void HighScoresFromGameOver()
    {
        highScoresUI.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
    }

    private void GameOverFromHighScores()
    {
        gameOverUI.gameObject.SetActive(true);
        highScoresUI.gameObject.SetActive(false);
    }

    private void MainMenuFromGameOver()
    {
        SceneManager.LoadScene(0);
    }

    private void GameOver(int score)
    {
        gameOverUI.gameObject.SetActive(true);
        if (gmHighScores.IsHighScore(score))
        {
            gameOverUI.ShowHighScoreText();
            gameOverUI.ShowNameInputField();
        }
    }

    /*private void UpdateHighScores(HighScore highScore)
    {
        gmHighScores.UpdateHighScores(highScore);
    }*/

    private void ExitGame()
    {
        gmSaveLoadData.SaveData(gmHighScores.HighScores);

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
    }
}
