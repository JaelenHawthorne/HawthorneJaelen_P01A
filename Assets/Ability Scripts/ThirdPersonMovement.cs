using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{

    /// parrticles

    public GameObject Shockwave;
    public GameObject Sparks;

    public GameObject Hearts;
    public GameObject HitEffect;

    /// 

    public AudioSource sounds;
    public AudioClip heal;
    public AudioClip walk;
    public AudioClip jump;
    public AudioClip land;
    public AudioClip death;


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
        sounds = GetComponent<AudioSource>();


    }

    void Update()
    {



        //




        //

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

                sounds.clip = jump;
                sounds.PlayOneShot(sounds.clip);
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

    public void Dead()
    {
        controller.enabled = false;
        turnSmoothTime = 1110;
        anim.SetBool("IsDead", true);
    }

    public void Hurt()
    {
        anim.SetTrigger("Hurt");
        Instantiate(HitEffect, transform.position, transform.rotation);
    }

    public void Cure()
    {
        anim.SetTrigger("Heal");
        Instantiate(Hearts, transform.position, transform.rotation);
    }

    private void Fall()
    {
        AudioClip fall = land;
        sounds.PlayOneShot(fall);
        Instantiate(Shockwave, transform.position, transform.rotation);

    }

    private void Step()
    {
        AudioClip step = walk;
        sounds.PlayOneShot(step);
        Instantiate(Sparks, transform.position, transform.rotation);

    }

    private void Die()
    {
        AudioClip die = death;
        sounds.PlayOneShot(die);

    }

}
