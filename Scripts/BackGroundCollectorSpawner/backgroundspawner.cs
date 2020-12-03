using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundspawner : MonoBehaviour
{

    [SerializeField]
    GameObject[] backgrounds;
    float lastY;

    void  Start() {
     SetLastY();   
    }

    void SetLastY(){
        backgrounds = GameObject.FindGameObjectsWithTag("BackGround");
        lastY = backgrounds[0].transform.position.y;
        for(int i = 1; i < backgrounds.Length; i++){
            if(lastY > backgrounds[i].transform.position.y){
                lastY = backgrounds[i].transform.position.y;
            }
        }
        Debug.Log("Last Y is: " + lastY);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
        if(other.tag == "BackGround"){
            Debug.Log("LastY :" + lastY + "   ?= " +  other.transform.position.y);
            if(lastY == other.transform.position.y){
                Vector3 temp = other.transform.position;
                float height = ((BoxCollider2D)other).size.y;
                for(int i = 0; i < backgrounds.Length; i++){
                    if(!backgrounds[i].activeInHierarchy){
                        temp.y -= height;
                        lastY = temp.y;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                    }
                }
            }

        }     
    }
}
