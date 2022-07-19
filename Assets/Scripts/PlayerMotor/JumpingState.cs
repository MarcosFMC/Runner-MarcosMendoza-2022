﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : BaseState
{
    public float jumpForce = 7f;

    public override void Construct()
    {
        _motor.verticalVelocity = jumpForce;
        _motor._anim.SetTrigger("Jump");
    }

    public override Vector3 ProcessMotion()
    {

        _motor.ApplyGravity();

        Vector3 m = Vector3.zero;

        m.x = _motor.SnapToLane();
        m.y = _motor.verticalVelocity;
        m.z = _motor.baseRunSpeed;

        return m;
    }

    public override void Transition()
    {
        if (InputManager.Instance.SwipeLeft)
        {
            _motor.ChangeLane(-1);
        }

        if (InputManager.Instance.SwipeRight)
        {
            _motor.ChangeLane(1);
        }

        if (_motor.verticalVelocity < 0)
            _motor.ChangeState(GetComponent<FallingState>());
    }
}
