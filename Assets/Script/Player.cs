using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private float horizontal;

    public Transform groundCheck;
    public Rigidbody2D rb;

    public bool isJumping;
    public bool isGrounded;



    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * horizontal * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position);
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

    }

        void MovePlayer(float _horizontalMovement)
    {
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

}

