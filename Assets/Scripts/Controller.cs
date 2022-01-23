using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<KeyCode> keyCodes;
    private float _currentY;
    private float _defaultY;
    private int _maxAngle = 60;
    private int _speed = 1000;
    private bool _isKeyDown = false;
    private Vector3 _startAngles;

    // Start is called before the first frame update
    void Start()
    {
        _startAngles = transform.localRotation.eulerAngles;
        _defaultY = _startAngles.y;
        _currentY = _defaultY;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
            {
                _isKeyDown = true;
            }
            else if (Input.GetKeyUp(keyCode))
            {
                _isKeyDown = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Animations(_isKeyDown);
    }

    private void Animations(bool keyDown)
    {
        if (_startAngles.y < 180)
        {
            if (keyDown && _defaultY - _currentY <= _maxAngle)
            {
                _currentY -= Time.fixedDeltaTime * _speed;
            }

            if (!keyDown && _currentY < _defaultY)
            {
                _currentY += Time.fixedDeltaTime * _speed;
            }
        }
        else
        {
            if (keyDown && _currentY - _defaultY <= _maxAngle)
            {
                _currentY += Time.fixedDeltaTime * _speed;
            }

            if (!keyDown && _defaultY < _currentY)
            {
                _currentY -= Time.fixedDeltaTime * _speed;
            }
        }

        Rotate(_currentY);
    }

    private void Rotate(float y)
    {
        Vector3 vector3 = new Vector3(0, y, 90);
        transform.localRotation = Quaternion.Euler(vector3);
    }
}