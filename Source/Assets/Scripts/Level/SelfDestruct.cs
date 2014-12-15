using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public Transform player;
    private Transform self;
    public float destroyUpdate = 5;
    private float currentUpdate;

    void Start()
    {
        currentUpdate = 0;
        this.self = gameObject.transform;
    }

	// Update is called once per frame
	void Update () {
        currentUpdate += Time.deltaTime;
        if (currentUpdate > destroyUpdate)
        {
            currentUpdate = 0;
            if (self.position.z < player.position.z)
            {
                Destroy(gameObject);
            }
        }
	}
}
