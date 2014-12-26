using UnityEngine;
using System.Collections;

public class AirplaneAttack : BaseAttack
{
  
    void Update()
    {
      
        if (CanShoot() && Input.GetButton("Fire1") && (bulletsLoaded > 0))
        {
            Debug.Log("Shoot");
            Fire();
            bulletsLoaded--;
            Reload();
        }
    }

}
