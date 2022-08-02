using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    public GameObject healPickup;
    public Transform firePoint;
    public UnityEvent OnDamageTaken;
    public UnityEvent OnDeath;
    public UnityEvent OnHeal;

    public GameObject DamagingAnim;
    public GameObject HealingAnim;


    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        OnDamageTaken?.Invoke();
        //play animation of taking dmg
        if (currentHealth<=0)
        {
            currentHealth = maxHealth;
            OnDeath?.Invoke();
        }
    }
    public void Heal(float amount)
    {
        currentHealth += amount;
        OnHeal?.Invoke();

        //play animation of taking dmg
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void TakingDamage()
    {
        Instantiate(DamagingAnim, transform.position, Quaternion.identity);
    }
    public void Healing()
    {
        Instantiate(HealingAnim, transform.position, Quaternion.identity);
        // HealingAnim.GetComponent<Animator>().enabled=true;
    }
    public void destroyEnemy()
    {
        if(gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    public void destroy_Instantiate()
    {
        
        Instantiate(healPickup, transform.position, transform.rotation);
        // Instantiate(healPickup, firePoint.position, firePoint.rotation);
        Destroy(gameObject);
    }

}
