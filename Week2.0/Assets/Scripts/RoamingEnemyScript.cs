using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingEnemyScript : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
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
    Vector2 previousPoint;
    Vector2 positionbeformove;
    public float speed = 10f;
    public Rigidbody2D rigidBody;
    private void Start()
    {
        currWeapon = GetComponent<Weapon>();
        state = State.Idle;
        previousPoint = transform.position;
        positionbeformove = new Vector2(0,0);
    }
    private void Update()
    {
        switch(state)
        {
            case State.Idle: //will be sitting idle for certain period of time then start roaming and get back here
                FindTarget();  // in the state and in roaming will be finding player if found ==> start shooting
                if(Time.time > waitTime)
                {
                    // Debug.Log("Idling");
                    float wait = 1f;
                    waitTime = Time.time + wait;
                    state = State.Roaming;
                }
                break;
            case State.Roaming:
                FindTarget();
                if(Time.time > waitTime)
                {
                    // Debug.Log("Roaming");
                    float wait = 2f;
                    waitTime = Time.time + wait;
                    state = State.Idle;
                }
                break;
            case State.shooting:
                FindTarget();
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
        else if(state == State.Roaming)
           MoveToRandomPosition();
    }
    void MoveToRandomPosition()
    {
        // Vector2 point;
        if(previousPoint+positionbeformove == (Vector2)gameObject.transform.position)
        {
            //Debug.Log("Here");
            positionbeformove = previousPoint;
            previousPoint= GetValidPostion();
        }
        //Debug.Log((Vector2)transform.position + point);
        // Vector2 direction = previousPoint - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.CircleCast(transform.position,0.025f, previousPoint, 5f, layerMask);
        // Debug.Log($"Enemy {(hit.transform.position + point}");
        // Debug.Log($"Player {player.transform.position}");
        //Debug.Log(previousPoint);
        if(!hit)
        {
            // Debug.Log(positionbeformove+previousPoint);
            // Debug.Log(gameObject.transform.position);
            float angle = Mathf.Atan2(previousPoint.y, previousPoint.x) * Mathf.Rad2Deg - 90f;
            rigidBody.rotation = angle;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, (Vector2)gameObject.transform.position + previousPoint, speed*Time.deltaTime);
        }
        else
            previousPoint = GetValidPostion();
    }

    Vector2 GetValidPostion()
    {
        //generate random angle
        Vector2 point;
        float length =5f;
        float angle = UnityEngine.Random.Range(0, 360);
        point.x = length * Mathf.Cos(angle * Mathf.Deg2Rad);
        point.y = length * Mathf.Sin(angle * Mathf.Deg2Rad);
        // point.y = 1f;
        return point;
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
            // Debug.Log("Enemy Incoming!!!");
            state = State.shooting;
        }
    }
}
    
