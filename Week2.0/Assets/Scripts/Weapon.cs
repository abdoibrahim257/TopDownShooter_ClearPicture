using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public float fireForce;
    public abstract void Shoot();
    public abstract void DontShoot();
}
    //laser code
    //public static bool laser;
    //public LineRenderer lineRenderer;
    //private void Start()
    //{
    //    lineRenderer = GetComponent<LineRenderer>();
    //    lineRenderer.enabled = false;
    //    lineRenderer.useWorldSpace = true;
    //}
        //Bullet bullet = projectileBullet.GetComponent<Bullet>();
        //bullet.anyName.AddListener(bullet.Impact);
    
        //else
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        //    if(hit.collider && Input.GetMouseButton(0))
        //    {
        //        //play particle effect
        //        lineRenderer.enabled = true;
        //        var mouseposition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        lineRenderer.SetPosition(0, FirePoint.position);
        //        lineRenderer.SetPosition(1, mouseposition);
        //    }
        //    else
        //    {
        //        if(Input.GetMouseButton(0))
        //        {
        //            lineRenderer.enabled = true;
        //            var mouseposition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //            lineRenderer.SetPosition(0, FirePoint.position);
        //            lineRenderer.SetPosition(1, mouseposition);
        //        }
        //        else
        //        {
        //            lineRenderer.enabled = false;
        //            laser = false;
        //        }
        //    }
        //}
