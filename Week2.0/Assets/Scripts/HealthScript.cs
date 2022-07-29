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

    public GameObject DamagingAnim;
    public GameObject HealingAnim;


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
            currentHealth = maxHealth;
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
    public void destroyTurret()
    {
        if(gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
