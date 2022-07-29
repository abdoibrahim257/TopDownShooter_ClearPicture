using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class turretController : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rigidBody;
    Weapon currWeapon;
    public UnityEvent DestroyTurret;


    private void Start() 
    {
        currWeapon = GetComponent<Weapon>();    //in this turret it will be always projectile so no need to call it in update
    }

    public void ShootPlayer()
    {
        if(currWeapon)
            currWeapon.Shoot();
    }

    private void FixedUpdate() 
    {
        RotateTurret();
    }
    
    void RotateTurret()
    {
        Vector2 playerPosition = (Vector2) Player.transform.position;
        Vector2 TurretPosition = playerPosition - rigidBody.position;   
        float aimAngle = Mathf.Atan2(TurretPosition.y,TurretPosition.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = aimAngle;
    }
}
