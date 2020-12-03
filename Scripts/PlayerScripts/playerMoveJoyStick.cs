using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveJoyStick : MonoBehaviour
{
    float speed = 8f, maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;
    bool moveLeft, moveRight;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        if(moveLeft){
            MoveLeft();
        }
        else if (moveRight){
            MoveRight();
        }    
    }

    public void SetMoveLeft(bool move)
    {
        this.moveLeft = move;
        this.moveRight = !moveLeft;
    }
    void MoveLeft()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        if (vel < maxVelocity)
        {
            forceX = -speed;
        }

        Vector3 temp = transform.localScale;
        temp.x = -1;
        transform.localScale = temp;
        anim.SetBool("Walk", true);
        myBody.AddForce(new Vector2(forceX, 0));
    }
    void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        if (vel < maxVelocity)
        {
            forceX = speed;
        }

        Vector3 temp = transform.localScale;
        temp.x = 1;
        transform.localScale = temp;
        anim.SetBool("Walk", true);
        myBody.AddForce(new Vector2(forceX, 0));
    }

    public void StopMove()
    {
        moveLeft = moveRight = false;
        anim.SetBool("Walk", false);
    }



}
