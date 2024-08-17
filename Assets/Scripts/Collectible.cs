using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Action CollectAction;

    private void OnTriggerEnter(Collider other)
    {
        print("1");
        if (other.CompareTag("Player"))
        {
            CollectAction();
            //Add VFX
            Destroy(gameObject);
        }
    }
}
