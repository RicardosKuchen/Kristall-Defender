using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentScript : MonoBehaviour
{
    public CharacterController controller;
    public Camera fov;

    public float speed = 12f;
    public float runspeed = 1.5f;
    public float MaxFov = 90f;
    public float LowFov = 70f;
    public float t = 0.1f;
    public float gravity = -9.81f;
    public float jumpheight = 3f;

    public int magicCount = 0;

    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButton("Fire3"))
        {
            move = move * runspeed;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, MaxFov, t);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, LowFov, t / 2);
        }           

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

