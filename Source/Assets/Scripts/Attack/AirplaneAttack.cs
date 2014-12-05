using UnityEngine;
using System.Collections;

public class AirplaneAttack : BaseAttack
{
    void Update()
    {
        if (CanShoot() && Input.GetKey(KeyCode.Space))
        {
            Fire();
            Reload();
        }
    }
}
