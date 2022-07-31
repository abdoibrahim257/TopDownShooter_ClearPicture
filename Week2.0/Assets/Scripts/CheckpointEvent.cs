using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CheckpointEvent : MonoBehaviour
{
    public UnityEvent<Vector3> CheckPoint;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
            CheckPoint?.Invoke(this.gameObject.transform.position);
    }
}
