using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInScene : MonoBehaviour
{
    public UnityEvent OnPlayerEnter;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            //Invoke event
            OnPlayerEnter?.Invoke();
        }    
    }
}
