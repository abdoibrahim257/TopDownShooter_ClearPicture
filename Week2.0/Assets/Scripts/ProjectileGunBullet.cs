using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileGunBullet : MonoBehaviour
{
    public UnityEvent<GameObject, GameObject> OnHit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHit?.Invoke(collision.gameObject, this.gameObject);
    }
}
