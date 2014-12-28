using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AirplaneAttack : MonoBehaviour, IAttacker {

    public Transform[] guns;
    public GameObject bullet;
    public AudioClip shotSound;
    public int bulletsLoaded = 100;
    public float reloadTime = .5f;
    private ElementStats stats;
    private float nextFireTime;
    public int damage;
    public bool affectsScore;

    void Awake()
    {
        this.stats = GetComponent<ElementStats>();
    }

    GameObject bulletInstance;
    Bullet bulletScript;

    public void Fire()
    {
        if (CanShoot())
        {
            foreach (var gun in guns)
            {
                bulletInstance = GameObjectsManager.GetObject("bullet");

                if (bulletInstance == null) {
                    bulletInstance = (GameObject)Instantiate(bullet, gun.position, gun.rotation);
                } else {
                    bulletInstance.transform.position = gun.position;
                    bulletInstance.transform.rotation = gun.rotation;
                    bulletInstance.gameObject.SetActive(true);
                }

                bulletScript = bulletInstance.GetComponent<Bullet>();
                bulletScript.damage = damage;
                bulletScript.affectsScore = affectsScore;

                bulletInstance = null;
            }
            
            this.audio.PlayOneShot(this.shotSound);
            Reload();
        }
    }

    private void Reload()
    {
        nextFireTime = Time.time + reloadTime;
        bulletsLoaded--;
    }

    private bool CanShoot()
    {
        return Time.time >= nextFireTime && bulletsLoaded > 0 && !stats.IsDead();
    }
}
