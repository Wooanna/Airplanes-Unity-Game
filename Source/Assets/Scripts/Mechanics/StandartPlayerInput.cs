using UnityEngine;
using System.Collections;

public class StandartPlayerInput : BasePlayerMechanics {

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
}
