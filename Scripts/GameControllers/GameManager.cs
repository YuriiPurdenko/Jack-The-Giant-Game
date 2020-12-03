using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private enum DiffLevel { Easy, Medium, Hard };

    public static GameManager instance;

    [HideInInspector]
    public bool GameStartedFromMainMenu, GameStartedAfterPlayerDied;
    [HideInInspector]
    public int score, coinsScore, lifeScore;
    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        InitializeVariables();
    }

    void InitializeVariables()
    {
        const string GAME_INITED_KEY = "Game Initialized";
        if (!PlayerPrefs.HasKey(GAME_INITED_KEY))
        {
            GamePreferences.SetEasyDifficultyState(false);
            GamePreferences.SetEasyDifficultyCoinScore(0);
            GamePreferences.SetEasyDifficultyHighscore(0);

            GamePreferences.SetMediumDifficultyState(true);
            GamePreferences.SetMediumDifficultyCoinScore(0);
            GamePreferences.SetMediumDifficultyHighscore(0);

            GamePreferences.SetHardDifficultyState(false);
            GamePreferences.SetHardDifficultyCoinScore(0);
            GamePreferences.SetHardDifficultyHighscore(0);
            GamePreferences.SetMusicState(true);

            PlayerPrefs.SetInt(GAME_INITED_KEY, 1);
        }
    }
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GamePlay")
        {
            if (GameStartedAfterPlayerDied)
            {
                GameController.instance.SetCoins(coinsScore);
                GameController.instance.SetLife(lifeScore);
                GameController.instance.SetScore(score);
                PlayerScore.ScoreCount = score;
                PlayerScore.CoinCount = coinsScore;
                PlayerScore.LifeCount = lifeScore;
            }
            else
            {
                GameController.instance.SetCoins(0);
                GameController.instance.SetLife(2);
                GameController.instance.SetScore(0);
                PlayerScore.ScoreCount = 0;
                PlayerScore.CoinCount = 0;
                PlayerScore.LifeCount = 2;
            }
        }
    }
    public void CheckGameStatus(int score, int coins, int life)
    {
        if (life < 0)
        {
            GameStartedAfterPlayerDied = false;
            GameStartedFromMainMenu = false;
            OnGameOver(coins, score);
            GameController.instance.GameOver(coins, score);

        }
        else
        {
            GameStartedAfterPlayerDied = true;
            this.score = score;
            this.coinsScore = coins;
            this.lifeScore = life;
            GameStartedFromMainMenu = false;
            GameController.instance.RestartPlayerAfterDied();
        }
    }

    DiffLevel GetDiffLevel()
    {
        if (GamePreferences.GetEasyDifficultyState())
        {
            return DiffLevel.Easy;
        }
        else if (GamePreferences.GetMediumDifficultyState())
        {
            return DiffLevel.Medium;
        }
        else
        { // if (GamePreferences.GetHardDifficultyState()) {
            return DiffLevel.Hard;
        }

    }

    int GetHighScore(DiffLevel level)
    {
        switch (level)
        {
            case DiffLevel.Easy:
                return GamePreferences.GetEasyDifficultyHighscore();
            case DiffLevel.Medium:
                return GamePreferences.GetMediumDifficultyHighscore();
            case DiffLevel.Hard:
                return GamePreferences.GetHardDifficultyHighscore();
        }
        throw new System.SystemException("unhandled level");

    }
    void SetHighScore(DiffLevel level, int score)
    {
        switch (level)
        {
            case DiffLevel.Easy:
                GamePreferences.SetEasyDifficultyHighscore(score);
                break;
            case DiffLevel.Medium:
                GamePreferences.SetMediumDifficultyHighscore(score);
                break;
            case DiffLevel.Hard:
                GamePreferences.SetHardDifficultyHighscore(score);
                break;
            default:
                throw new System.SystemException("unhandled level");
        }

    }

    void UpdateScore(DiffLevel level, int score)
    {
        int highScore = GetHighScore(level);
        if (highScore < score)
        {
            SetHighScore(level, score);
        }

    }
    int GetHighCoins(DiffLevel level)
    {
        switch (level)
        {
            case DiffLevel.Easy:
                return GamePreferences.GetEasyDifficultyCoinScore();
            case DiffLevel.Medium:
                return GamePreferences.GetMediumDifficultyCoinScore();
            case DiffLevel.Hard:
                return GamePreferences.GetHardDifficultyCoinScore();
        }
        throw new System.SystemException("unhandled level");

    }
    void SetHighCoins(DiffLevel level, int coins)
    {
        switch (level)
        {
            case DiffLevel.Easy:
                GamePreferences.SetEasyDifficultyCoinScore(coins);
                break;
            case DiffLevel.Medium:
                GamePreferences.SetMediumDifficultyCoinScore(coins);
                break;
            case DiffLevel.Hard:
                GamePreferences.SetHardDifficultyCoinScore(coins);
                break;
            default:
                throw new System.SystemException("unhandled level");
        }

    }

    void UpdateCoins(DiffLevel level, int coins)
    {
        int highCoins = GetHighCoins(level);
        if (highCoins < coins)
        {
            SetHighScore(level, coins);
        }

    }
    void OnGameOver(int coins, int score)
    {

        DiffLevel level = GetDiffLevel();
        UpdateCoins(level, coins);
        UpdateScore(level, score);
    }

}
