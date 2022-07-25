using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject Projectile;
    public float fireForce;

    public void Fire()
    {
        GameObject projectileBullet = Instantiate(Projectile, FirePoint.position, FirePoint.rotation); //once this function is called it fires a bullet 
        //line 13 alone instantiates a bullet from "FirePoint" only without projection
        projectileBullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * fireForce, ForceMode2D.Impulse); //throws off the bullet with fire force value
    }


}
