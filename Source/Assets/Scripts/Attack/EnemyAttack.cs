using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AirplaneAttack))]
public class EnemyAttack : MonoBehaviour
{
    IAttacker attacker;

    void Start()
    {
        attacker = (IAttacker)gameObject.GetComponent<AirplaneAttack>();

        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (true)
        {
            attacker.Fire();

            yield return null;
        }
    }
}
