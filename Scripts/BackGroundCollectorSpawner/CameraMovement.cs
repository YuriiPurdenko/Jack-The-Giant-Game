using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 1f;
    float maxSpeed = 3.2f;
    float accemleration = 0.2f;

    private float easySpeed = 3.2f;
    private float mediumSpeed = 3.7f;
    private float hardSpeed = 4.2f;

    [HideInInspector] public bool cameraMove;
    void Start()
    {
        if(GamePreferences.GetEasyDifficultyState()){
            maxSpeed = easySpeed;
        }
        else if(GamePreferences.GetMediumDifficultyState()){
            maxSpeed = mediumSpeed;
        }
        else if (GamePreferences.GetHardDifficultyState()){
            maxSpeed = hardSpeed;
        }
        cameraMove = true;        
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraMove){
            CameraMove();
        }
        
    }

    void CameraMove(){
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);
        temp.y = Mathf.Clamp(temp.y, oldY, newY);
        transform.position = temp;
        speed += accemleration * Time.deltaTime;

        if(speed > maxSpeed){
            speed = maxSpeed;
        }
    }
}
