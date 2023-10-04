using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Detector : MonoBehaviour
{
    //public
    public Resource_Manager resourceManager;

    //Si un Objecto entra al trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Resources>())
        {
            resourceManager.AddResources(other.gameObject.GetComponent<Resources>().value);
            Destroy(other.gameObject);
        }
    }
}
