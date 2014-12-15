using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BaseAttack : MonoBehaviour {

    public Transform[] guns;
    public GameObject bullet;
    public AudioClip shotSound;

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

        this.audio.PlayOneShot(this.shotSound);
    }

    protected bool CanShoot()
    {
        return Time.time >= nextFireTime;
    }
}
