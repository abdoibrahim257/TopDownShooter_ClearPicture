using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorScript : MonoBehaviour
{
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void ChangeColor()
    {
        //Debug.Log(gameObject.GetComponent<SpriteRenderer>().color);
        if(sr.color == Color.red)
        {
            //change color to green
            sr.color =new Color(0f,1f,0f,1f);
            //Debug.Log(sr.color);
            // gameObject.GetComponentInChildren<Light>().color = Color.green;
        }
    }

}
