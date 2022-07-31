using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemy : MonoBehaviour
{
    private enum State{
        Finding,
        Charging,
        Engaging,
    }
    public Rigidbody2D rigidBody;
    public GameObject Player;
    private State state;
    private float TimeToCharge;
    private void Start() 
    {
       state = State.Finding;
    }

    private void Update()
    {
        switch(state)
        {
            case(State.Finding):
                //make enemy move randomlyy to be added
                // Debug.Log("Enemy looking for player");
                Findtarget(); 
                break;
            case(State.Charging):

                if (Time.time > TimeToCharge)
                {
                    Debug.Log("Enemy Charging HEREEEEEEEEEEEEEE");
                    //play animation of charging
                    // RotateCharger();
                    float FixedRate = 3f;
                    TimeToCharge = Time.time + FixedRate;
                    state = State.Engaging;
                }
                break;
            case(State.Engaging):
            {
                if(Time.time > TimeToCharge)
                {
                    Debug.Log("Enemy incoming");
                    
                    //throw the enemy with force to toward the player
                    this.gameObject.GetComponent<Rigidbody2D>().AddForce(this.gameObject.transform.up * 30000000, ForceMode2D.Impulse);
                    float fixedRate = 4f;
                    TimeToCharge = Time.time + fixedRate;
                    state = State.Charging;
                }
            }
                break;

        }
    }
    void FixedUpdate()
    {
        if(state == State.Engaging)
        {
            Debug.Log("enemy Rotating");
            RotateCharger();
        }
    }

    void RotateCharger()
    {
        // Debug.Log("Enemy Rotating");
        Vector2 playerPosition = (Vector2) Player.transform.position;
        Vector2 TurretPosition = playerPosition - this.gameObject.GetComponent<Rigidbody2D>().position;   
        float aimAngle = Mathf.Atan2(TurretPosition.y,TurretPosition.x) * Mathf.Rad2Deg - 90f;
        this.gameObject.GetComponent<Rigidbody2D>().rotation = aimAngle;
    }

    private void Findtarget()
    {
        float targetRange = 15f;
        if(Vector3.Distance(transform.position, Player.transform.position) < targetRange)
        {
            //player in range
            // ChangeColorScript stater too charging
            state = State.Charging;
        }
    }

}
