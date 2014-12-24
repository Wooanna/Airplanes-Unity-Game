using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BaseAttack : MonoBehaviour {

    public Transform[] guns;
    public GameObject bullet;
    public AudioClip shotSound;

    private ElementStats stats;

    public float reloadTime = .5f;
    protected float nextFireTime;

    void Awake()
    {
        this.stats = GetComponent<ElementStats>();
    }

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

        this.audio.Stop();
        this.audio.PlayOneShot(this.shotSound);
    }

    protected bool CanShoot()
    {
        return Time.time >= nextFireTime && !stats.IsDead();
    }
}
