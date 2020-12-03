using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float minX, maxX;
    void Start()
    {
        SetMaxAndMinX();
    }

    // Update is called once per frame
    void Update()
    {
        if(minX > transform.position.x){
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }
        if(maxX < transform.transform.position.x){
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }

    void SetMaxAndMinX(){
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.2f;
        minX = -bounds.x + 0.2f;
    }


}
