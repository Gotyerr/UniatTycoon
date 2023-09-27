using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variables publicas
    public float sensibility;
    public Transform targetObject, cameraAimY;
    public bool canRotate;

    // Variables privadas
    private float xRotation, yRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        xRotation = 0f;
        yRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Si podemos rotar
        if (canRotate)
        {
            Rotate();
        }

        // Seguimos al objetivo
        FollowTarget();
    }

    // Funcion para rotar la camara
    void Rotate()
    {
        // Conseguir los inputs del mouse
        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensibility;
        yRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensibility;

        // Limitar la rotacion en Y
        yRotation = Mathf.Clamp(yRotation, -65, 65);

        // Rotamos los componentes X y Y de la camara
        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        cameraAimY.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
    }

    // Funcion para seguir al objetivo
    void FollowTarget()
    {
        transform.position = targetObject.position;
    }
}   