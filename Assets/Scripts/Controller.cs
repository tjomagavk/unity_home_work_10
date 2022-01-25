using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<KeyCode> keyCodes;
    public HingeJoint _joint;
    public bool _motorEnable;

    void Update()
    {
        foreach (var keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
            {
                EnableMotor(true);
            }
            else if (Input.GetKeyUp(keyCode))
            {
                EnableMotor(false);
            }
        }
    }

    private void EnableMotor(bool enable)
    {
        _joint.useMotor = enable;
    }
}