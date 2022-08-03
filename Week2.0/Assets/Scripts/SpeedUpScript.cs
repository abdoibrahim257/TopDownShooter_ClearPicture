using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpScript : MonoBehaviour
{
    public bool Temp = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<Weapon>() && other.GetComponent<Weapon>() == other.GetComponent<ProjectileGun>())
            {
                Debug.Log("Plyaer wants an upgrade!");
                // currweapon =other.GetComponent<ProjectileGun>();
                // BULLET.IncreaseDmg();
                other.GetComponent<ProjectileGun>().TimeBetweenShots /=2;
                other.GetComponent<ProjectileGun>().Temp(Temp);
                other.GetComponent<ProjectileGun>().SetTimeSinceUpgrade(Time.time);
                other.GetComponent<ProjectileGun>().RevertSpeed(true);
            }
            Destroy(gameObject);
        }

    }
}
