using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;

    public UnityEvent OnDamageTaken;
    public UnityEvent OnDeath;
    public UnityEvent OnHeal;


    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        OnDamageTaken?.Invoke();
        //play animation of taking dmg
        if (currentHealth<=0)
        {
            OnDeath?.Invoke();
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
        OnHeal?.Invoke();

        //play animation of taking dmg
        if (currentHealth > maxHealth)
        {
            //play death animation
            //we are dead
            currentHealth = maxHealth;
        }
    }
}
