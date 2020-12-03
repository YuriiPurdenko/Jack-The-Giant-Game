using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    playerMoveJoyStick player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<playerMoveJoyStick>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "LeftButton")
        {
            Debug.Log("LeftButton");
            player.SetMoveLeft(true);
        }
        else
        {
            Debug.Log("RightButton");
            player.SetMoveLeft(false);

        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        player.StopMove();
    }
}