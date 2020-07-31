using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour { 

    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    public bool jump = false;
    public bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxisRaw("Horizontal"));        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }

        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        animator.SetBool("CrouchCheck", crouch);

        animator.SetBool("JumpCheck", jump);
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
