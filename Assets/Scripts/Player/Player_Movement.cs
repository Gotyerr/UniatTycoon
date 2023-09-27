using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Variables publicas
    public float walkSpeed, runSpeed, rotationSpeed;
    public bool canMove;
    public Transform cameraAim;

    // Variables privadas
    private Vector3 movementVector;
    private float speed;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        speed = 0f;
        movementVector = Vector3.zero;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si nos podemos ver
        if (canMove)
        {
            Walk();
            Run();
            AlignPlayer();
        }

        // Gravedad provisional
        Gravity();
    }
    // Funcion para caminar
    void Walk()
    {
        // Conseguimos los inputs WASD
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");

        // Normalizar el vector de movimiento
        movementVector = movementVector.normalized;

        // Movernos en direccion a la camara
        movementVector = cameraAim.TransformDirection(movementVector);

        // Nos movemos
        characterController.Move(movementVector * speed * Time.deltaTime);
    }

    // Funcion para correr
    void Run()
    {
        // Si presionamos el boton para correr modificamos la velocidad
        if (Input.GetAxis("Run") > 0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

    // Funcion para alinear al jugador hacia el movimiento
    void AlignPlayer()
    {
        // Alineamos al jugador si nos estamos moviendo
        if (characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementVector), rotationSpeed * Time.deltaTime);
        }
    }

    // Funcion de gravedad provisional
    void Gravity()
    {
        characterController.Move(new Vector3(0f, -4f * Time.deltaTime, 0f));
    }


}