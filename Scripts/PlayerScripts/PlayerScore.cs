using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinAudio, lifeAudio;
    private CameraMovement cameraMovement;

    public static bool IsScoreCount;
    private Vector3 prevPos;
    public static int ScoreCount;
    public static int CoinCount;
    public static int LifeCount;

    void Awake()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    void Start()
    {
        prevPos = transform.position;
        IsScoreCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }

    void CountScore()
    {

        if (IsScoreCount)
        {
            if (prevPos.y < transform.position.y)
            {
                ScoreCount++;
            }
            prevPos = transform.position;
        }
        GameController.instance.SetScore(ScoreCount);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Coin")
        {
            CoinCount++;
            ScoreCount += 200;
            AudioSource.PlayClipAtPoint(coinAudio, transform.position);
            GameController.instance.SetCoins(CoinCount);
            GameController.instance.SetScore(ScoreCount);
            other.gameObject.SetActive(false);
        }
        if (other.tag == "Life")
        {
            LifeCount++;
            ScoreCount += 300;
            GameController.instance.SetLife(LifeCount);
            GameController.instance.SetScore(ScoreCount);
            AudioSource.PlayClipAtPoint(lifeAudio, transform.position);
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Bounds" || other.tag == "Deadly")
        {
            LifeCount--;
            GameController.instance.SetLife(LifeCount);
            GameManager.instance.CheckGameStatus(ScoreCount,CoinCount,LifeCount);
            IsScoreCount = false;
            cameraMovement.cameraMove = false;
            transform.position = new Vector3(500, 500, 0);
        }
    }

}
