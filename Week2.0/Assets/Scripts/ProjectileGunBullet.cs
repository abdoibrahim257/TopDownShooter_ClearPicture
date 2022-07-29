using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileGunBullet : MonoBehaviour
{
    public GameObject impactCollision;
    public int Damage;
    public UnityEvent<GameObject, GameObject> OnHit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        OnHit?.Invoke(collision.gameObject, this.gameObject);
    }


    public void Impact(GameObject collidedWith, GameObject collidingObject)
    {
        if (collidedWith.CompareTag("wall"))
        {
            Destroy(collidingObject);
            if(impactCollision)
                Instantiate(impactCollision, collidingObject.transform.position, Quaternion.identity);
        }
    }

    public void DmgPlayer(GameObject collidedWith, GameObject collidingObject)
    {
        //.........
        if (collidedWith.CompareTag("Player"))
        {
            //decrease players health
            Debug.Log("Player Hit");
            Destroy(collidingObject);
            if(collidedWith.GetComponent<HealthScript>())
                collidedWith.GetComponent<HealthScript>().TakeDamage(Damage);
        }
    }

    public void EnemyImpact(GameObject collidedWith, GameObject collidingObject)
    {
        if(collidedWith.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            Destroy(collidingObject);
            if(collidedWith.GetComponent<HealthScript>())
                collidedWith.GetComponent<HealthScript>().TakeDamage(Damage);
        }
    }
}
