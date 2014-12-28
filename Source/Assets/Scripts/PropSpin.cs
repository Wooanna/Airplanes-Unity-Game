using UnityEngine;
using System.Collections;

public class PropSpin : MonoBehaviour {

    public float spinIntervalTime;

    Material material;
    WaitForSeconds spinInterval;
    Vector2 offsetUpdate = new Vector2(.25f, 0);

	// Use this for initialization
	void Start () {
        material = renderer.material;
        this.spinInterval = new WaitForSeconds(spinIntervalTime);

        StartCoroutine(SpinProp());
	}
	
	IEnumerator SpinProp()
    {
        while (true)
        {
            yield return spinInterval;

            material.mainTextureOffset += offsetUpdate;
        }
    }
}
