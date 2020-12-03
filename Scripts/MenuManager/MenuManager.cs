using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button musicBtn;
    [SerializeField]
    private Sprite[] musicBtnSprites;
    void Start()
    {
        CheckMusic();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void HighScoreMenu()
    {
        SceneManager.LoadScene("HighScoreMenu");
    }
    public void OptionMenu()
    {
        SceneManager.LoadScene("OptionMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }


    void CheckMusic()
    {
        if (GamePreferences.GetMusicState())
        {
            musicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicBtnSprites[0];
        }
        else
        {
            musicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicBtnSprites[1];
        }
    }

    public void MusicButton()
    {
        if (GamePreferences.GetMusicState())
        {
            GamePreferences.SetMusicState(false);
            musicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicBtnSprites[1];
        }
        else
        {
            GamePreferences.SetMusicState(true);
            musicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicBtnSprites[0];
        }
    }
}
