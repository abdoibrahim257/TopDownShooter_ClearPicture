using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour
{
    public int Amount;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<HealthScript>())
                other.GetComponent<HealthScript>().Heal(Amount);
            Destroy(this.gameObject);
        }
    }
}
