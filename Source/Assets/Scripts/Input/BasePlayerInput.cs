using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AirplaneMechanics))]
[RequireComponent(typeof(AirplaneAttack))]
public abstract class BasePlayerInput : MonoBehaviour
{
    IAirplaneController airplaneController;
    IAttacker attacker;
    float inputX;
    float inputY;
    float inputAcceleration;

    void Start()
    {
        this.airplaneController = (IAirplaneController)gameObject.GetComponent<AirplaneMechanics>();
        this.attacker = (IAttacker)gameObject.GetComponent<AirplaneAttack>();
    }

    void Update()
    {
        inputX = GetHorizontalAxis();
        inputY = GetVerticalAxis();
        inputAcceleration = GetAccelerationAxis();

        if (inputX > 0)
        {
            this.airplaneController.GoRight();
        } else if (inputX < 0)
        {
            this.airplaneController.GoLeft();
        } else
        {
            this.airplaneController.KeepCenterHorizontal();
        }
        
        if (inputY > 0)
        {
            this.airplaneController.GoUp();
        } else if (inputY < 0)
        {
            this.airplaneController.GoDown();
        } else
        {
            this.airplaneController.KeepCenterVertical();
        }
        
        if (inputAcceleration > 0)
        {
            this.airplaneController.SpeedUp();
        } else if (inputAcceleration < 0)
        {
            this.airplaneController.SlowDown();
        } else
        {
            this.airplaneController.KeepConstantSpeed();
        }

        if (GetFire())
        {
            this.attacker.Fire();
        }
    }

    protected abstract bool GetFire();

    protected abstract float GetHorizontalAxis();

    protected abstract float GetVerticalAxis();

    protected abstract float GetAccelerationAxis();
}
