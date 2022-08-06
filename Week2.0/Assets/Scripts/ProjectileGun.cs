using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileGun : Weapon
{
    //public Rigidbody2D rigidBody;
    public GameObject Projectile;
    public float BulletDamage;
    private float nextShootTime;
    public float TimeBetweenShots=0.3f;
    private float fireForce= 40;
    public float NumberOfProjectile = 1;//default equal 1
   // public UnityEvent<GameObject, GameObject> OnHit;
    // bool canShoot;
    GameObject projectileBullet;
    bool WantAnUpgrade;
    bool TemporaryUpgrade;
    float TimeSinceUpgrade;
    bool revertSpeed;
    bool revertDamage;

    private void Start()
    {
        // BulletDamage = 2;
        WantAnUpgrade = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time>nextShootTime && gameObject.CompareTag("Player"))
        {
            nextShootTime = Time.time + TimeBetweenShots;
            Shoot();
        }

        if(GetTemp() && (Time.time - TimeBetweenShots >= 15f))
        {
            //revert upgrade 
            //first let us see what type of updrage it was
            if(revertSpeed)
            {
                TimeBetweenShots = 0.3f;
            }
            else if(revertDamage)
            {
                WantAnUpgrade = false;
            }
        }
    }
    public override void Shoot()
    {
        if (NumberOfProjectile == 1)
        {
            projectileBullet = Instantiate(Projectile, FirePoint.position, FirePoint.rotation); //once this function is called it fires a bullet 
            if(WantAnUpgrade && gameObject.CompareTag("Player"))
            {
                projectileBullet.GetComponent<ProjectileGunBullet>().SetDmg(BulletDamage);
                projectileBullet.GetComponent<ProjectileGunBullet>().IncreaseDmg();
                Debug.Log( projectileBullet.GetComponent<ProjectileGunBullet>().GetDmg());
            }
            else 
            {
                projectileBullet.GetComponent<ProjectileGunBullet>().SetDmg(BulletDamage);
                Debug.Log( projectileBullet.GetComponent<ProjectileGunBullet>().GetDmg());
            }
            projectileBullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * fireForce, ForceMode2D.Impulse); //throws off the bullet with fire force value
        }
    }
    public override void DontShoot()
    {
        //...
        // canShoot = false;
    }
    public void SetUpgrade(bool wantAnUpgrade)
    {
        WantAnUpgrade = wantAnUpgrade;
    }

    public void Temp(bool temp)
    {
        TemporaryUpgrade = temp;
    }

    bool GetTemp()
    {
        return TemporaryUpgrade;
    }

    public void SetTimeSinceUpgrade(float time)
    {
        TimeSinceUpgrade = time;
    }
    public void RevertSpeed(bool revert)
    {
        revertSpeed = revert;
    }
     public void RevertDamage(bool revert)
    {
        revertDamage = revert;
    }
}
