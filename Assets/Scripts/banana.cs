using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class banana : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        transform.position += new Vector3(speed / 100, 0, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wolf"))
        {
            //other.gameObject.GetComponent<hunger3>().AddHunger(0.1f);
            Destroy(gameObject);
        }
    }
}
