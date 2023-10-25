 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public Ground_Detector groundDetector;

    private float speed;
    private bool isGrounded;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0f;
        isGrounded = true;
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        CheckSpeed();
        SetParameters();

        
    }

    void SetParameters()
    {
        animator.SetFloat("Speed", speed);
        animator.SetBool("isGrounded", isGrounded);
    }

    public void CheckSpeed()
    {
        speed = playerMovement.GetCurrentSpeed();
    }

    public void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }
}
