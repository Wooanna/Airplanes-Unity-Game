using UnityEngine;
using System.Collections;

public class EnemyAttack : BaseAttack
{
    void Start()
    {
        Reload();
    }

    void Update()
    {
        if (CanShoot())
        {
            Fire();
            Reload();
        }
    }
}
