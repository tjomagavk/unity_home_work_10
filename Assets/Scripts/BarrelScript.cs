using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public float speed;
    public float angle;
    public float vx = 1;
    public float vy = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayersManager.GetPlayer())
        {
            
            Vector3 direction = Vector3.forward;
            other.GetComponent<Rigidbody>().AddForce(direction * 200, ForceMode.Impulse);
            // other.GetComponent<Rigidbody>().AddForce(other.transform.position.normalized * 100, ForceMode.Impulse);
        }
    }

   
}
