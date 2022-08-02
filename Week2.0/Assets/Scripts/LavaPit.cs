using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPit : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("lavaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            if(player.GetComponent<HealthScript>())
                player.GetComponent<HealthScript>().TakeDamage(0.2f);
        }    
    }
}
