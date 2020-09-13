using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;


    public float speed;

    public float walkSpeed = 6f;
    public float sprintSpeed = 20f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float jumpSpeed = 30.0f;
    public float gravity = 20.0f;

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;



        if (controller.isGrounded)
        {
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpSpeed;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
            }
            else
            {
                speed = 6f;
            }

        }


        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

        
    }
}
