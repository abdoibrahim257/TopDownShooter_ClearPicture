using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPickupScript : MonoBehaviour
{
   // Weapon weapon;
    public float Range;
    public LayerMask layerMask;
    public Transform firePoint;
    public GameObject player;
    public Camera camera;
    public LineRenderer lineRenderer;
    public GameObject laserImpact;

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //player.AddComponent<Laser>();
            //player will be holding only gun at a time and he will be removing it first and the assignin it later '
            //first
            Debug.Log("Laser Gun");
            //Second
            //assign new component to the player with the gun
            Weapon curweapon= player.GetComponent<Weapon>();
            if (curweapon == null || curweapon == player.GetComponent<ProjectileGun>())
            {
                Destroy(player.GetComponent<Weapon>());
                player.AddComponent<Laser>();
                //now that we have created a new laser we have to Clone the paemeters for it to work and turn of collider
                this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                Laser l = player.GetComponent<Laser>();
                //copying the stuff
                if (l)
                {
                    l.Range = Range;
                    l.layerMask = layerMask;
                    l.FirePoint = firePoint;
                    l.cam = camera;
                    l.lineRenderer = lineRenderer;
                    l.LaserImpact = laserImpact;
                }
                Destroy(this.gameObject);
            }
            else if(curweapon == player.GetComponent<Laser>())
                Destroy(this.gameObject);
        }
    }
}
