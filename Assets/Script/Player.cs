using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float
    public float moveSpeed;
    public float jumpForceStanding;
    public float jumpForceCrouching;
    public float cd;

    

    //private float
    private float horizontal;

    //public component
    public Transform groundCheck1;

    public GameObject groundCheckStanding;
    public Transform groundCheck2;
    public GameObject groundCheckCrouching;
    public Rigidbody2D rb;
    public LayerMask groundLayer;
    public BoxCollider2D col;
    public Animator anim;
    //public GameObject CheckRight;
    //public GameObject CheckLeft;

    //Formule pour aller chercher dans d'autres scripts
    public Projectile projectilePrefab;
    public Transform LaunchOffSet;

    //public Vector2
    public Vector2 StandingSize;
    public Vector2 StandingOffSet;
    public Vector2 CrouchingSize;
    public Vector2 CrouchingOffSet;

    //SerializeField private bool
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isStanding;
    [SerializeField] private bool isCrouching;
    [SerializeField] private bool isFacingRight = true;

    //public bool
    public bool HasKey1 = false;
    public bool HasKey2 = false;
    public bool cdAtteinte = true;


    private void Start()
    {
        isStanding = true;
    }

   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * horizontal * moveSpeed * Time.deltaTime);

        Flip();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && cdAtteinte)
        {
            StartCoroutine(Shoot());
        }

       




        ///////////////////////////////////////////////////Code pour s'accroupir///////////////////////////////////////////////////

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isStanding = false;
            isCrouching =true;
            col.size = CrouchingSize;
            col.offset = CrouchingOffSet;
            groundCheckStanding.SetActive(false);
            groundCheckCrouching.SetActive(true);
        }


        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isCrouching = false;
            isStanding = true;
            col.size = StandingSize;
            col.offset = StandingOffSet;
            groundCheckStanding.SetActive(true);
            groundCheckCrouching.SetActive(false);

        }

        if (isCrouching)
        {
            anim.SetBool("isCrouching", true);
        }
        else
        {
            anim.SetBool("isCrouching", false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }


    //faire une coroutine pour mettre du temps entre chacun de mes lanc�s
    IEnumerator Shoot()
    {
        cdAtteinte = false;
        Instantiate(projectilePrefab, LaunchOffSet.position, transform.rotation);
        yield return new WaitForSeconds(cd);
        cdAtteinte = true;
    }

    public void GetKey1()
    {
        HasKey1 = true;
    }

    public void GetKey2()
    {
        HasKey2 = true;
    }

    void FixedUpdate()
    {
        if (!isCrouching) isGrounded = Physics2D.OverlapCircle(groundCheck1.position, 0.1f, groundLayer); 
        else isGrounded = Physics2D.OverlapCircle(groundCheck2.position, 0.1f, groundLayer);
        
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontal);

       
    }

    void MovePlayer(float _horizontal)
    {
        ///////////////////////////////////////////////////Code pour s'accroupir///////////////////////////////////////////////////

        if (isJumping && isStanding)
        {
            //forcemode2d.impulse ajoute direct une impulsion au rigidbody
            rb.AddForce(Vector2.up * jumpForceStanding, ForceMode2D.Impulse);
            isJumping = false;
        }

        if (isJumping && isCrouching)
        {
            rb.AddForce(new Vector2(0f, jumpForceCrouching));
            isJumping = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    private void Flip()
    {

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}

