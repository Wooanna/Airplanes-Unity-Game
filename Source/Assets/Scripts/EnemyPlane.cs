using UnityEngine;
using System.Collections;

public class EnemyPlane : BaseAirplaneMechanics {

	public void Awake () {
        base.Awake();
	}
	
	public void Update () {
        base.Update();
        airplane.Translate(forewardMovement, Space.Self);
	}
}
