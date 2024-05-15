using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float
    public float moveSpeed;
    public float jumpForceStanding;
    public float jumpForceCrouching;

    //private float
    private float horizontal;

    //public component
    public Transform groundCheck;
    public Rigidbody2D rb;
    public LayerMask groundLayer;
    public BoxCollider2D col;

    //public Vector2
    public Vector2 StandingSize;
    public Vector2 StandingOffSet;
    public Vector2 CrouchingSize;
    public Vector2 CrouchingOffSet;

    //public bool
    public bool isJumping;
    public bool isGrounded;
    public bool isStanding;
    public bool isCrouching;


    private void Start()
    {
        isStanding = true;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * horizontal * moveSpeed * Time.deltaTime);
     

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isStanding = false;
            isCrouching =true;
            col.size = CrouchingSize;
            col.offset = CrouchingOffSet;
        }


        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isCrouching = false;
            isStanding = true;
            col.size = StandingSize;
            col.offset = StandingOffSet;
        }

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontal);

    }

    void MovePlayer(float _horizontal)
    {
 
        if (isJumping && isStanding)
        {
            rb.AddForce(new Vector2(0f, jumpForceStanding));
            isJumping = false;
        }

        if (isJumping && isCrouching)
        {
            rb.AddForce(new Vector2(0f, jumpForceCrouching));
            isJumping = false;
        }
    }

}

