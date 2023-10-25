using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Variables publicas
    public float walkSpeed, runSpeed, jumpForce, rotationSpeed;
    public bool canMove;
    public Transform cameraAim;
    public Ground_Detector ground_Detector;

    // Variables privadas
    private Vector3 movementVector, verticalForce;
    private float speed, currentSpeed;
    private CharacterController characterController;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        speed = 0f;
        currentSpeed = 0f;
        movementVector = Vector3.zero;
        verticalForce = Vector3.zero;
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
            Jump();
        }

        // Gravedad 
        Gravity();
        CheckGround();
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

        currentSpeed = Mathf.Lerp(currentSpeed, movementVector.magnitude * speed, 10f * Time.deltaTime);

        // Nos movemos
        characterController.Move(movementVector * currentSpeed * Time.deltaTime);
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
        if (!isGrounded)
        {
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
            characterController.Move(new Vector3(0f, -2f * Time.deltaTime, 0f));
        }

        characterController.Move(verticalForce * Time.deltaTime);
    }

    void Jump()
    {
        if(isGrounded & Input.GetAxis("Jump") > 0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }

    void CheckGround()
    {
        isGrounded = ground_Detector.GetIsGrounded();
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

}