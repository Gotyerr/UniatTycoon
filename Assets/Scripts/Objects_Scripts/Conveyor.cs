using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{

    //publicas
    public float speed;

    //privadas
    private Vector3 movementVector3;

    // Start is called before the first frame update
    void Start()
    {
        movementVector3 = transform.forward * speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Resources>())
        {
            Transform colliderObject = collision.gameObject.transform;
            colliderObject.position = new Vector3(colliderObject.position.x + movementVector3.x * Time.deltaTime,
                                                  colliderObject.position.y + movementVector3.y * Time.deltaTime,
                                                  colliderObject.position.z + movementVector3.z * Time.deltaTime);
        }

    }
}
