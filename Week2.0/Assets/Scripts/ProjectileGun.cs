using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileGun : Weapon
{
    //public Rigidbody2D rigidBody;
    public GameObject Projectile;
    //public GameObject impactCollision; //here
    private float nextShootTime;
    public float TimeBetweenShots=0.3f;
    private float fireForce= 40;
    public float NumberOfProjectile = 1;//default equal 1
   // public UnityEvent<GameObject, GameObject> OnHit;
    // bool canShoot;

    // private void Start()
    // {
    //     canShoot = false;
    // }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time>nextShootTime && gameObject.CompareTag("Player"))
        {
            Shoot();
            nextShootTime = Time.time + TimeBetweenShots;
        }
        // else if(Time.time>nextShootTime && gameObject.CompareTag("Enemy"))
        // {
        //     Shoot();
        //     nextShootTime = Time.time + TimeBetweenShots;
        // }
        // else if(canShoot && gameObject.CompareTag("Enemy"))
        //     Shoot();
    }
    public override void Shoot()
    {
        if (NumberOfProjectile == 1)
        {
            GameObject projectileBullet = Instantiate(Projectile, FirePoint.position, FirePoint.rotation); //once this function is called it fires a bullet 
            projectileBullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * fireForce, ForceMode2D.Impulse); //throws off the bullet with fire force value
            //Debug.Log(gameObject.tag);
            //projectileBullet.GetComponent<ProjectileGunBullet>().OnHit = OnHit; //link on hit event here and with bullet itself    //here
            //delay
            // canShoot = false;
            // StartCoroutine(ShotCoolDown()); 
        }
        else if (NumberOfProjectile > 1)
        {

        }
    }

    public override void DontShoot()
    {
        //...
        // canShoot = false;
    }
    IEnumerator ShotCoolDown() 
    {
        yield return new WaitForSeconds(TimeBetweenShots);
        // canShoot = true;
    }

    //here

    //public void Impact(GameObject collidedWith, GameObject collidingObject)
    //{
    //    if (collidedWith.CompareTag("wall"))
    //    {
    //        Destroy(collidingObject);    
    //        Instantiate(impactCollision, collidingObject.transform.position, Quaternion.identity);
    //    }
    //}

    //public void DmgPlayer(GameObject collidedWith, GameObject collidingObject)
    //{
    //    //.........
    //    if(collidedWith.CompareTag("Player"))
    //    {

    //    }
    //}

    //public void EnemyImpact(GameObject collidedWith, GameObject collidingObject)
    //{
    //    //.........
    //}

    //for delay

    //public override Weapon Clone(GameObject source, GameObject destination)
    //{
    //    //throw new System.NotImplementedException();
    //}
}
