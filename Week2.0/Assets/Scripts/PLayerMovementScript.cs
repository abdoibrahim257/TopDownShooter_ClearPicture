using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovementScript : MonoBehaviour
{
    public float speed = 0f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    // Update is called once per frame
    void Update()
    {
        //for processing inputs
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized; //to get input from one vector only 

    }
    void FixedUpdate()
    {
        //for movement
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
}
