using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public abstract void Shoot();
    public abstract void DontShoot();
    //public abstract Weapon Clone(GameObject source, GameObject destination);

}
