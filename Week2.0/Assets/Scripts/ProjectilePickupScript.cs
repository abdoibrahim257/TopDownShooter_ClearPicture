using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectilePickupScript : MonoBehaviour
{
    public GameObject player;
    public Transform firePoint;
    public GameObject projectile;
    //public GameObject impactCollision;
    // public float dmg;
    public float NOP;
    //public UnityEvent<GameObject, GameObject> onHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //player.AddComponent<Laser>();
            //player will be holding only gun at a time and he will be removing it first and the assignin it later '
            //first
            // Debug.Log("Projectile Gun");
            //Second
            //assign new component to the player with the gun
            Weapon currweapon = player.GetComponent<Weapon>();
            if (currweapon == null || currweapon == player.GetComponent<Laser>())
            {
                Destroy(player.GetComponent<Weapon>());
                player.AddComponent<ProjectileGun>();
                //now that we have created a new laser we have to Clone the paemeters for it to work and turn of collider
                this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                ProjectileGun p = player.GetComponent<ProjectileGun>();
                //copying the stuff
                if (p)
                {
                    p.FirePoint = firePoint;
                    p.Projectile = projectile;
                    //p.impactCollision = impactCollision;
                    p.NumberOfProjectile = NOP;
                    //p.OnHit = onHit;
                }
                Destroy(this.gameObject);
            }
            else if (currweapon == player.GetComponent<ProjectileGun>())
            {
                Destroy(this.gameObject);
            }
        }
    }
}
