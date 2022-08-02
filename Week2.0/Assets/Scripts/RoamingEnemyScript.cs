using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingEnemyScript : MonoBehaviour
{
    private enum State
    {
        Idle,
        Roaming, //while roaming we will be searching for the player
        shooting
    }
    public GameObject player;
    private Weapon currWeapon;
    private State state;
    float timeToShoot;
    float waitTime;

    private void Start() 
    {
        currWeapon = GetComponent<Weapon>();
        state = State.Idle;      
    }


    private void Update() 
    {
        switch(state)
        {
            case State.Idle: //will be sitting idle for certain period of time then start roaming and get back here
                FindTarget();  // in the state and in roaming will be finding player if found ==> start shooting
                if(Time.time > waitTime)
                {
                    Debug.Log("Idling");
                    float wait = 3f;
                    waitTime = Time.time + wait;
                    state = State.Roaming;
                }
                break;
            case State.Roaming:
            FindTarget();
                if(Time.time > waitTime)
                {
                    Debug.Log("Moving Randomly");
                    float wait = 3f;
                    waitTime = Time.time + wait;
                    state = State.Idle;
                }
                break;
            case State.shooting:
                if(Time.time>timeToShoot)
                {
                    float fixedFireRate= 0.333333f;
                    ShootPlayer();
                    timeToShoot = Time.time +fixedFireRate;
                }
                break;
        }    
    }
    public void ShootPlayer()
    {
        if(currWeapon)
            currWeapon.Shoot();
    }

    private void FixedUpdate() 
    {
        if(state == State.shooting)
            RotateEnemy();    
    }

        void RotateEnemy()
    {
        // Debug.Log("Enemy Rotating");
        Vector2 playerPosition = (Vector2) player.transform.position;
        Vector2 TurretPosition = playerPosition - this.gameObject.GetComponent<Rigidbody2D>().position;
        float aimAngle = Mathf.Atan2(TurretPosition.y,TurretPosition.x) * Mathf.Rad2Deg - 90f;
        this.gameObject.GetComponent<Rigidbody2D>().rotation = aimAngle;
    }

    private void FindTarget()
    {
        float targetRange = 30f;
        if(Vector3.Distance(transform.position, player.transform.position) < targetRange)
        {
            //player in range
            // ChangeColorScript stater too charging
            state = State.shooting;
        }
    }
}
    // private Vector3 startingPosition;

    // private void Start() 
    // {
    //     startingPosition = transform.position;    
    // }

    // private Vector3 GetRoamingPosition()
    // {
    //     return startingPosition + new Vector3(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f,1f)).normalized * Random.Range(10f,70f);
    // }
