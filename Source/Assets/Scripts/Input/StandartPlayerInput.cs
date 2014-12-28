using UnityEngine;
using System.Collections;

public class StandartPlayerInput : BasePlayerInput {

	protected override float GetHorizontalAxis()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    protected override float GetVerticalAxis()
    {
        return Input.GetAxisRaw("Vertical");
    }

    protected override float GetAccelerationAxis()
    {
        return Input.GetAxisRaw("Acceleration");
    }

    protected override bool GetFire()
    {
        return Input.GetButton("Fire1");
    }
}
