using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    private Collision _ball;
    private float _power;
    private int _maxPower = 500;
    private bool _process;
    public List<KeyCode> keyCodes;

    // Start is called before the first frame update
    void Start()
    {
        ResetPower();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
            {
                _process = true;
            }
            else if (Input.GetKeyUp(keyCode))
            {
                _process = false;
                Push();
            }
        }
    }

    private void FixedUpdate()
    {
        if (_process && _power <= _maxPower)
        {
            _power += +Time.fixedDeltaTime * 30;
        }
    }

    private void Push()
    {
        if (_ball != null)
        {
            Vector3 vector3 = _ball.transform.position - transform.position;
            // Vector3 vector3 = new Vector3(0, 1, 0);
            _ball.rigidbody.AddForce(vector3.normalized * _power, ForceMode.Impulse);
        }

        ResetPower();
    }

    private void ResetPower()
    {
        _power = 50;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayersManager.GetPlayer())
        {
            _ball = other;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (_ball == null && other.gameObject.layer == LayersManager.GetPlayer())
        {
            _ball = other;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayersManager.GetPlayer())
        {
            _ball = null;
        }
    }
}