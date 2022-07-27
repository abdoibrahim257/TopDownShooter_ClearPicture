using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        //play animation of taking dmg
        if(currentHealth<=0)
        {
            //play death animation
            //we are dead
        }
    }
    void Heal(int amount)
    {
        currentHealth += amount;
        //play animation of taking dmg
        if (currentHealth < maxHealth)
        {
            //play death animation
            //we are dead
            currentHealth = maxHealth;
        }
    }
}
