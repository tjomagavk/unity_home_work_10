using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private List<KeyCode> keyCodes;
    [SerializeField] private HingeJoint joint;

    void Update()
    {
        if (GetKeyDown())
        {
            EnableMotor(true);
        }

        if (GetKeyUp())
        {
            EnableMotor(false);
        }
    }

    private bool GetKeyDown()
    {
        foreach (var keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
            {
                return true;
            }
        }

        return false;
    }

    private bool GetKeyUp()
    {
        foreach (var keyCode in keyCodes)
        {
            if (Input.GetKeyUp(keyCode))
            {
                return true;
            }
        }

        return false;
    }

    private void EnableMotor(bool enable)
    {
        joint.useMotor = enable;
    }
}