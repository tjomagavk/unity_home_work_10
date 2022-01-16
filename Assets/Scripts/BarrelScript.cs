using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public Light _pointLight;

    private void Start()
    {
        if (_pointLight == null)
        {
            _pointLight = GetComponentInChildren<Light>();
        }

        _pointLight.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        _pointLight.enabled = !_pointLight.enabled;
    }
}