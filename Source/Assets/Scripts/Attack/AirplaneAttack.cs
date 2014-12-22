using UnityEngine;
using System.Collections;

public class AirplaneAttack : BaseAttack
{
    void Update()
    {
        if (CanShoot() && Input.GetButton("Fire1"))
        {
            Fire();
            Reload();
        }
    }
}
