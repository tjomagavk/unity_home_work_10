using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        Vector3 vector3 = other.transform.position - transform.position;
        other.rigidbody.AddForce(vector3.normalized * 5, ForceMode.Impulse);
    }
}