using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public GameObject impactCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "wall":
                //Destroy(gameObject);
                Impact();
                break;
        }
    }

    void Impact()
    {
        Instantiate(impactCollision, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
