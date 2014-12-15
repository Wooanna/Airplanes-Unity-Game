using UnityEngine;
using System.Collections;

public class BaseAttack : MonoBehaviour {

    public Transform[] guns;
    public GameObject bullet;

    public float reloadTime = .5f;
    protected float nextFireTime;

    protected void Reload()
    {
        nextFireTime = Time.time + reloadTime;
    }

    protected void Fire()
    {
        foreach (var gun in guns)
        {
            Instantiate(bullet, gun.position, gun.rotation);
        }
    }

    protected bool CanShoot()
    {
        return Time.time >= nextFireTime;
    }
}
