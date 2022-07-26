using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public float LaserRange;
    public override void Shoot()
    {
        Debug.Log("LASER INCOMMING");
        lineRenderer.enabled = true;
        var mousePosition = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, mousePosition);
        Vector2 direction = mousePosition - (Vector2)FirePoint.position;
        RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, direction.normalized, LaserRange);
        //Debug.Log(hit.collider.tag);
        //.collider.attachedRigidbody.tag != "Player"
        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
            //call a particle system
        }
    }

    public override void DontShoot()
    {
        lineRenderer.enabled = false;
        Debug.Log("no Laser");
    }
}
