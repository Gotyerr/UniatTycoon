using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Detector : MonoBehaviour
{
    public float radius;
    public LayerMask detectedLayers;

    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        
    }


    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(transform.position, radius, detectedLayers);
    }

    public bool GetIsGrounded()
        {

        return isGrounded;

        }
}
