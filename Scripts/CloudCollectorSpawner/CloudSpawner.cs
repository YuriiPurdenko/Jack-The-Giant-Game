using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloudSpawner : MonoBehaviour
{


    [SerializeField] GameObject[] clouds;

    float minX;
    float maxX;
    float controlX = 0f;
    float distanceBetweenClouds = 3f;
    float lastCloudPositionY;
    [SerializeField] GameObject[] collectables;
    private GameObject player;

    void Awake()
    {
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");
        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].SetActive(false);
        }
    }


    void Start()
    {
        PlayerPosition();
    }
    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;

    }


    void Shuffle(GameObject[] toShuffle)
    {
        for (int i = 0; i < toShuffle.Length; i++)
        {
            GameObject temp = toShuffle[i];
            int random = Random.Range(0, toShuffle.Length);
            toShuffle[i] = toShuffle[random];
            toShuffle[random] = temp;
        }
    }

    void CreateClouds()
    {
        Shuffle(clouds);
        float positionY = 0f;
        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            if (controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;

            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;

            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;

            }
            positionY -= distanceBetweenClouds;
            temp.y = positionY;
            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
        }

    }
    void PlayerPosition()
    {
        GameObject[] deadly = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");
        for (int i = 0; i < deadly.Length; i++)
        {
            if (deadly[i].transform.position.y == 0)
            {
                Vector3 temp = deadly[i].transform.position;
                deadly[i].transform.position = cloudsInGame[i].transform.position;
                cloudsInGame[i].transform.position = temp;
            }
        }

        Vector3 t = cloudsInGame[0].transform.position;
        for (int i = 1; i < cloudsInGame.Length; i++)
        {
            if (t.y < cloudsInGame[i].transform.position.y)
            {
                t = cloudsInGame[i].transform.position;
            }
        }
        t.y += 0.8f;
        player.transform.position = t;

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cloud" || other.tag == "Deadly")
        {
            Vector3 temp = other.transform.position;
            if (temp.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                Shuffle(collectables);
                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            controlX = 1;
                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0.0f, minX);
                            controlX = 2;

                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX = 3;

                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0;

                        }
                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;
                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectables.Length);
                        if (clouds[i].tag != "Deadly")
                        {
                            if (!collectables[random].activeInHierarchy)
                            {
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.7f;
                                if (collectables[random].tag == "Life")
                                {
                                    if (PlayerScore.LifeCount < 2)
                                    {
                                        collectables[random].transform.position = temp2;
                                        collectables[random].SetActive(true);
                                    }
                                }
                                else
                                {
                                    collectables[random].transform.position = temp2;
                                    collectables[random].SetActive(true);
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}
