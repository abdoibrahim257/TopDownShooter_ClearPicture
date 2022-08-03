using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWidthUp : MonoBehaviour
{
    public bool Temp = false;
    private float currentTime;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<Weapon>() && other.GetComponent<Weapon>() == other.GetComponent<Laser>())
            {
                Debug.Log("Plyaer wants an upgrade!");
                // currweapon =other.GetComponent<ProjectileGun>();
                // BULLET.IncreaseDmg();
                other.GetComponent<LineRenderer>().widthMultiplier *=3;
                other.GetComponent<Laser>().IncreaseEnemyDamage();
                other.GetComponent<Laser>().Temp(Temp);
                other.GetComponent<Laser>().SetTimeSinceUpgrade(Time.time);

            }
            Destroy(gameObject);
        }
    }
}
