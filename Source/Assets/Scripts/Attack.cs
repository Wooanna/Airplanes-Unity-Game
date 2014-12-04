using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    public Transform[] guns;
    public GameObject bullet;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        foreach (var gun in guns)
        {
            Instantiate(bullet, gun.position, gun.rotation);
        }
    }

}
