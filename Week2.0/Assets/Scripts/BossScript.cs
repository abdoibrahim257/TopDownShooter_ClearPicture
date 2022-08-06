using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private enum State
    {
        Idle,
        Charging,
        Engaging,
        Shooting,
    }
    public GameObject player;
    Weapon currWeapon;
    Weapon currWeapon2;
    private State state;
    private float TimeToCharge;
    private float TimeToShoot;
    bool Engaging;
    int NumOfShoots;

    void Start()
    {
        currWeapon = GetComponents<Weapon>()[0];
        currWeapon2 = GetComponents<Weapon>()[1];
        state = State.Idle;        
    }

    private void Update()
    {
        switch(state)
        {
            case(State.Idle):
                Findtarget(); //once taget is foundchange to state charging 
                break;
            case(State.Charging): //will wait for couple of minutes and charge for a bit before engaging
                if(Time.time > TimeToCharge)
                {
                    Engaging = false;
                    Debug.Log("Boss is Charging");
                    float FixedRate = 2f;
                    TimeToCharge = Time.time + FixedRate;
                    state = State.Engaging;
                }
                break;
            case(State.Engaging): //after engaging after some times the state of shootig will be called 
                if(Time.time > TimeToCharge)
                {
                    Debug.Log("Enemy incoming");
                    //throw the enemy with force to toward the player
                    this.gameObject.GetComponent<Rigidbody2D>().AddForce(this.gameObject.transform.up * 60000000, ForceMode2D.Impulse);
                    Engaging = true;
                    float fixedRate = 3f;
                    TimeToShoot = Time.time + fixedRate;
                    // NumOfShoots = 0;
                    state = State.Shooting;
                    // animator.SetBool("isEngagin", false);
                }
                break;
            case(State.Shooting): // after shooting couple of shoots will return back to state of charging
                if(Time.time > TimeToShoot)
                {
                    float fixedFireRate= 0.15f;
                    ShootPlayer();
                    NumOfShoots++;
                    TimeToShoot = Time.time +fixedFireRate;
                }
                break;
        }
    }

    private void ShootPlayer()
    {
        if(currWeapon)
        {
            currWeapon.Shoot();
            currWeapon2.Shoot();
        }
    }
    private void FixedUpdate()
    {
        if(state == State.Charging)
            RotateBoss();
        else if(state == State.Shooting)
            RotateBoss();
        if(NumOfShoots == 15 && state == State.Shooting)
        {
            TimeToCharge = Time.time + 4;
            NumOfShoots = 0;
            state = State.Charging;
        }
    }

    void RotateBoss()
    {
        // Debug.Log("Enemy Rotating");
        Vector2 playerPosition = (Vector2) player.transform.position;
        Vector2 TurretPosition = playerPosition - this.gameObject.GetComponent<Rigidbody2D>().position;
        float aimAngle = Mathf.Atan2(TurretPosition.y,TurretPosition.x) * Mathf.Rad2Deg - 90f;
        this.gameObject.GetComponent<Rigidbody2D>().rotation = aimAngle;
    }

    private void Findtarget()
    {
        float targetRange = 40f;
        if(Vector3.Distance(transform.position, player.transform.position) < targetRange)
        {
            state = State.Charging;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //impulse effect on the player
            Vector3 hitVector = (other.gameObject.transform.position - transform.position).normalized;
            hitVector = (other.gameObject.transform.position - transform.position);
            // hitVector.y = 0;
            hitVector = hitVector.normalized ;
            other.rigidbody.AddForce(hitVector* 13000 );

            if(player.GetComponent<HealthScript>() && Engaging)
            {
                player.GetComponent<HealthScript>().TakeDamage(60);
            }
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
