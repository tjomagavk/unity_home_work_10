using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Open();
    }

    public void Open()
    {
        transform.GetComponent<Collider>().isTrigger = true;
        Color color = gameObject.GetComponent<Renderer>().material.color;
        gameObject.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0f);
    }

    private void Close()
    {
        transform.GetComponent<Collider>().isTrigger = false;
        Color color = gameObject.GetComponent<Renderer>().material.color;
        gameObject.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 1f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayersManager.GetPlayer())
        {
            Close();
        }
    }
}