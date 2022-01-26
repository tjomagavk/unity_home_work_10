using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    private Collision _ball;
    public Door door;
    private float _power;
    private int _maxPower = 150;
    private bool _process;
    private Renderer _renderer;
    private Color _defaultColor;
    public List<KeyCode> keyCodes;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
        ResetPower();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetKeyDown())
        {
            _process = true;
        }

        if (GetKeyUp())
        {
            _process = false;
            Push();
        }
    }

    private void FixedUpdate()
    {
        if (_process && _power <= _maxPower)
        {
            _power += Time.fixedDeltaTime * 100;
            var material = _renderer.material;
            Color currentColor = material.color;
            material.color = new Color(currentColor.g + (_power / _maxPower), currentColor.g, currentColor.b);
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

    private void Push()
    {
        if (_ball != null)
        {
            Vector3 vector3 = _ball.transform.position - transform.position;
            // Vector3 vector3 = new Vector3(0, 1, 0);
            _ball.rigidbody.AddForce(vector3.normalized * _power, ForceMode.Impulse);
            Debug.Log(_power);
        }

        ResetPower();
    }

    private void ResetPower()
    {
        _power = 20;
        _renderer.material.color = _defaultColor;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayersManager.GetPlayer())
        {
            _ball = other;
            door.Open();
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