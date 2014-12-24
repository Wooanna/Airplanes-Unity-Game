using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ElementStats))]
public class CollisionReaction : MonoBehaviour {

    ElementStats stats;
    string otherTag;

	// Use this for initialization
	void Awake () {
        this.stats = GetComponent<ElementStats>();
	}
	
    void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    void HandleCollision(GameObject other)
    {
        this.otherTag = other.tag;
        
        if (this.otherTag == "Obstacle" || this.otherTag == "Player" || this.otherTag == "Enemy")
        {
            stats.InflictDamage(int.MaxValue);
        }
    }
}
