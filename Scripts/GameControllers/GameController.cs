using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Text score;
    [SerializeField]
    Text life;
    [SerializeField]
    Text coins;
    [SerializeField]
    Text finalCoins;
    [SerializeField]
    Text finalScore;

    [SerializeField]
    GameObject PanelPause, GameOverPanel, ReadyButton;
    private CameraMovement cameraMovement;

    static public GameController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 0f;
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    public void GameOver(int coins, int score)
    {
        GameOverPanel.SetActive(true);
        finalCoins.text = coins.ToString();
        finalScore.text = score.ToString();
        Invoke("GameOverCoroutine", 2f);
    }

    void GameOverCoroutine()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartPlayerAfterDied()
    {
        SceneManager.LoadScene("GamePlay");
        Invoke("RestartPlayerCoroutine", 1f); 
    }


    void RestartPlayerCoroutine()
    {
        SceneManager.LoadScene("GamePlay");
    }



    public void SetCoins(int x)
    {
        coins.text = "x" + x;
    }

    public void SetLife(int x)
    {
        life.text = "x" + x;
    }

    public void SetScore(int x)
    {
        score.text = "x" + x;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PanelPause.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PanelPause.SetActive(false);

    }
    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Ready()
    {
        Time.timeScale = 1f;
        ReadyButton.SetActive(false);

    }

}
