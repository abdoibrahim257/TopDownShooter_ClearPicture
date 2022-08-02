using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class turretController : MonoBehaviour
{
    private enum State
    {
        Aiming,
        Shooting,
    }
    public GameObject Player;
    public Rigidbody2D rigidBody;
    Weapon currWeapon;
    public UnityEvent DestroyTurret;
    private State state;
    private float nextShootTime;

    private void Start() 
    {
        currWeapon = GetComponent<Weapon>();    //in this turret it will be always projectile so no need to call it in update
        state = State.Aiming;
    }

    private void Update() 
    {
        switch (state)
        {
            default:
            case State.Aiming:
                Findtarget(); //play animation of finding a target
                break;
            case State.Shooting:
                if(Time.time>nextShootTime)
                {
                    float fixedFireRate= 1f;
                    ShootPlayer();
                    nextShootTime = Time.time +fixedFireRate;
                }
                break;
        }
    }

    private void ShootPlayer()
    {
        if(currWeapon)
            currWeapon.Shoot();
    }

    private void FixedUpdate() 
    {
        if(state == State.Shooting)
            RotateTurret();
    }

    void RotateTurret()
    {
        Vector2 playerPosition = (Vector2) Player.transform.position;
        Vector2 TurretPosition = playerPosition - rigidBody.position;   
        float aimAngle = Mathf.Atan2(TurretPosition.y,TurretPosition.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = aimAngle;
    }

    private void Findtarget()
    {
        float targetRange = 30f;
        if(Vector3.Distance(transform.position, Player.transform.position) < targetRange)
        {
            //player in range
            state = State.Shooting;
        }
    }
}
