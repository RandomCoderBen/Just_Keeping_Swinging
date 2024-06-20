using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float gravity = -14f;
    public float jumpHight = 5f;

    private int JumpCount = 2;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded)
        {
            this.ResetJumps();

        }


        if (Input.GetButtonDown("Jump") && JumpCount > 0)
        {

            this.TakeJump();

            velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);


        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    

    public void ResetJumps()
    {
        this.JumpCount = 2;
    }

    public void TakeJump(int num = 1)
    {
        JumpCount -= num;
    }
    
}
