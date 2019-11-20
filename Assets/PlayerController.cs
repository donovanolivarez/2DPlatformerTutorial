using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    private float attackTimer = 0f;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool isAttacking = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Name of our parameter we created in the animator.
        // Mathf.abs is to get the absolute value. We need a positive value for horizontalMove, so this is necessary.
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("IsAttacking");
            animator.SetInteger("AttackType", Random.Range(1, 4));
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Base Layer") && Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("IsJumping", false);
            animator.SetTrigger("IsAttacking");
           // animator.SetBool("IsJumping", true);
        }
    }

    public void onLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
