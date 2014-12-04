using UnityEngine;
using System.Collections;

public class AirplaneAttack : BaseAttack
{
    void Update()
    {
        if (CanShoot() && Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
            Reload();
        }
    }
}
