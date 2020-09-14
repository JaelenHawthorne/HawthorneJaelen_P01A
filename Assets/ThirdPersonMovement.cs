using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThirdPersonMovement : MonoBehaviour
{



    public CharacterController controller;
    public Transform cam;
    public float speed;

    public float walkSpeed = 6f;
    public float sprintSpeed = 20f;

    public float turnSmoothTime = 0.1f;

    public Animator anim;


    float turnSmoothVelocity;

    public float jumpSpeed = 30.0f;
    public float gravity = 20.0f;

    private void Start()
    {
        
    }

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

       

        if (vertical < 0)
        {
            vertical = 0;
        } 

        if (controller.isGrounded)
        {
            anim.SetBool("Jumping", false);

            if (direction.magnitude >= 0.1f)
            {


                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);


                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);

                bool move = (vertical > 0) || (horizontal != 0);

                anim.SetBool("IsRunning", true);

            }
            else
            {
                anim.SetBool("IsRunning", false);
            }
          

            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpSpeed;

                anim.SetBool("Jumping", true);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
                anim.SetBool("Sprinting", true);
            }
            else
            {
                speed = 6f;
                anim.SetBool("Sprinting", false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("Attacking", true);
            }
            else
            {
                anim.SetBool("Attacking", false);
            }

        }


        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

        
    }

   
}
