using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public Light pointLight;

    void Start()
    {
        if (pointLight == null)
        {
            pointLight = GetComponentInChildren<Light>();
        }

        pointLight.enabled = false;
        BarrelsManager.Instance.RegisterBarrel(this);
    }

    public void LightOff()
    {
        pointLight.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        pointLight.enabled = !pointLight.enabled;
        BarrelsManager.Instance.BarrelActive(pointLight.isActiveAndEnabled);
        ScoreManager.Instance.AddScore(100);

        Vector3 vector3 = other.transform.position - transform.position;
        other.rigidbody.AddForce(vector3.normalized * 5, ForceMode.Impulse);
    }
}