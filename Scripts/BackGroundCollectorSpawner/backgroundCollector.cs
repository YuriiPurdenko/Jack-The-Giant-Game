using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "BackGround"){
            other.gameObject.SetActive(false);
        }    
    }
}
