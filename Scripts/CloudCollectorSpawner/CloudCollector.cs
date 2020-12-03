using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Cloud" || other.tag == "Deadly"){
            other.gameObject.SetActive(false);
        }    
   }
}
