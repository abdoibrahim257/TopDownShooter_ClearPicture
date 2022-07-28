using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public GameObject LaserImpact;
    private void Update()
    {
        if (Input.GetMouseButton(0))
            Shoot();
    }
    public override void Shoot()
    {
        Debug.Log("LASER INCOMMING");
        lineRenderer.enabled = true;
        var mousePosition = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)FirePoint.position;
        //Debug.Log(direction.magnitude);
        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, direction.normalized, direction.magnitude);
        //Debug.Log(hit.collider.tag);
        //.collider.attachedRigidbody.tag != "Player"
        if (hit)
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.CompareTag("wall"))
            {
                LaserImpact.GetComponent<ParticleSystem>().Play();
                lineRenderer.SetPosition(1, hit.point);
                LaserImpact.transform.position = lineRenderer.GetPosition(1);
            }
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
}
