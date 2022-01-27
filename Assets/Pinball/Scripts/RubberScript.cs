using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Vector3 vector3 = other.transform.position - transform.position;
        other.rigidbody.AddForce(vector3.normalized * 15, ForceMode.Impulse);
        gameObject.GetComponent<AudioSource>().Play();
    }
}