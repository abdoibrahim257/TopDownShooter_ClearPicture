using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    public float Range = 15f;
    public Camera cam;
    public LineRenderer lineRenderer;
    public GameObject LaserImpact;
    float enemyDamage;
    bool TemporaryUpgrade;
    float TimeSinceUpgrade;
    
    void Start()
    {
        enemyDamage = 0.15f;
        lineRenderer.widthMultiplier = 0.5f;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
            Shoot();
        if(GetTemp() && (Time.time - TimeSinceUpgrade >= 5f))
        {
            //revert changes
            lineRenderer.widthMultiplier=0.5f;
            DecreaseEnemyDamage();
        }
    }
    public override void Shoot()
    {
        //Debug.Log("LASER INCOMMING");
        Debug.Log(lineRenderer.widthMultiplier);
        lineRenderer.enabled = true;
        var mousePosition = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)FirePoint.position;
        //Debug.Log(direction.magnitude);
        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, (Vector2)FirePoint.position+ direction.normalized * Range);
        RaycastHit2D hit = Physics2D.CircleCast(FirePoint.position, 0.3f, direction,Range);
        //Debug.Log(hit.collider.tag);
        //.collider.attachedRigidbody.tag != "Player"
        if (hit)
        {
            // Debug.Log(hit.collider.tag);
            if(hit.collider.CompareTag("wall"))
            { 
                //do nothing
                LaserImpact.GetComponent<ParticleSystem>().Play();
                lineRenderer.SetPosition(1, hit.point);
                LaserImpact.transform.position = lineRenderer.GetPosition(1);
                // Debug.Log("Hit a wall");
            }
            else if(hit.collider.CompareTag("Enemy"))
            {
                //Debug.Log(hit.collider.tag);
                LaserImpact.GetComponent<ParticleSystem>().Play();
                lineRenderer.SetPosition(1, hit.point);
                LaserImpact.transform.position = lineRenderer.GetPosition(1);
                if(hit.collider.GetComponent<HealthScript>()) //IF SCRIPT EXITS ON THE ENEMY
                {
                    Debug.Log(enemyDamage);
                    hit.collider.GetComponent<HealthScript>().TakeDamage(enemyDamage);
                }
            }
            // else if(hit.collider.CompareTag("Player") && gameObject.CompareTag("Enemy"))
            // {
            //     LaserImpact.GetComponent<ParticleSystem>().Play();
            //     lineRenderer.SetPosition(1, hit.point);
            //     LaserImpact.transform.position = lineRenderer.GetPosition(1);
            //     if(hit.collider.GetComponent<HealthScript>())
            //         hit.collider.GetComponent<HealthScript>().TakeDamage(1);
            // }
        }
        else
        {
            Debug.Log("Not Hit");
        }
    }
    public override void DontShoot()
    {
        lineRenderer.enabled = false;
        Debug.Log("no Laser");
    }

    public void IncreaseEnemyDamage()
    {
        enemyDamage*=10;
    }
    void DecreaseEnemyDamage()
    {
        enemyDamage=0.15f;
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
}
