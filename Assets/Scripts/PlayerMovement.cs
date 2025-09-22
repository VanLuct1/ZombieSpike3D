using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f*2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f; // bán kính kiểm tra mặt đất
    public LayerMask groundMask; // lớp mặt đất

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // cham dat khong
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // nho hon 0 de cham dat
        }
        // di chuyen
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        // nhay
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            // cong thuc tinh van toc ban dau khi nhay
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // Falling down
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        // check move
        if(lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
            
        }
        else
        {
            isMoving = false;
        }
        lastPosition = gameObject.transform.position;
    }
}
