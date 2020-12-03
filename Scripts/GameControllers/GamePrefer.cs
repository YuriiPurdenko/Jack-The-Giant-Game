using System;
using System.Collections;
using UnityEngine;
public static class GamePreferences
{

    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";



    public static string IsTheMusicOn = "IsTheMusicOn";

    // 0 is off - 1 is on
    public static bool GetMusicState()
    {
        return PlayerPrefs.GetInt(GamePreferences.IsTheMusicOn) != 0;
    }

    // 0 is off - 1 is on
    public static void SetMusicState(bool enable)
    {
        PlayerPrefs.SetInt(GamePreferences.IsTheMusicOn, enable ? 1 : 0);
    }

    // method for getting easy difficulty state
    public static bool GetEasyDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty) != 0;
    }

    // method for setting easy difficulty state
    public static void SetEasyDifficultyState(bool enable)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, enable ? 1 : 0);
    }

    // method for getting medium difficulty state
    public static bool GetMediumDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty) != 0;
    }

    // method for setting medium difficulty state
    public static void SetMediumDifficultyState(bool enable)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, enable ? 1 : 0);
    }

    // method for getting hard difficulty state
    public static bool GetHardDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficulty) != 0;
    }

    // method for setting hard difficulty state
    public static void SetHardDifficultyState(bool enable)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficulty, enable ? 1 : 0);
    }

    // method for getting easy difficulty highscore
    public static int GetEasyDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyHighScore);
    }

    // method for setting easy difficulty highscore
    public static void SetEasyDifficultyHighscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, score);
    }

    // method for getting medium difficulty highscore
    public static int GetMediumDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyHighScore);
    }

    // method for setting medium difficulty highscore
    public static void SetMediumDifficultyHighscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, score);
    }

    // method for getting hard difficulty highscore
    public static int GetHardDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyHighScore);
    }

    // method for setting hard difficulty highscore
    public static void SetHardDifficultyHighscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, score);
    }

    // method for getting easy difficulty coin score
    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
    }

    // method for setting easy difficulty coin score
    public static void SetEasyDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, score);
    }

    // method for getting medium difficulty coin score
    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyCoinScore);
    }

    // method for setting medium difficulty coin score
    public static void SetMediumDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, score);
    }

    // method for getting hard difficulty coin score
    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
    }

    // method for setting hard difficulty coin score
    public static void SetHardDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, score);
    }

} // GamePreferences



















































































