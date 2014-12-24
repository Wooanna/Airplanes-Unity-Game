using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ElementStats))]
public class CollisionReaction : MonoBehaviour {

    ElementStats stats;

	// Use this for initialization
	void Awake () {
        this.stats = GetComponent<ElementStats>();
	}
	
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            stats.InflictDamage(int.MaxValue);
        }
    }
}
