using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HighScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, coinText;

    void Start()
    {
        SetScoreForDifficulty();
    }

    public void SetScore(int score, int coin)
    {
        scoreText.text = "" + score;
        coinText.text = "" + coin;
    }

    void SetScoreForDifficulty()
    {
        if (GamePreferences.GetEasyDifficultyState())
        {
            SetScore(GamePreferences.GetEasyDifficultyHighscore(), GamePreferences.GetEasyDifficultyCoinScore());
        }

        if (GamePreferences.GetMediumDifficultyState())
        {
            SetScore(GamePreferences.GetMediumDifficultyHighscore(), GamePreferences.GetMediumDifficultyCoinScore());
        }

        if (GamePreferences.GetHardDifficultyState())
        {
            SetScore(GamePreferences.GetHardDifficultyHighscore(), GamePreferences.GetHardDifficultyCoinScore());
        }
    }
    // Start is called before the first frame update
    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
