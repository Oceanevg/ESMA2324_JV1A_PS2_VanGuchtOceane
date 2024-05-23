using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouleEnemy : MonoBehaviour
{
    public float speed;
    public float temps;
    

   
    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {

       

        rb.velocity = new Vector2(speed, rb.velocity.y);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


    private void Awake()
    {
        Destroy(gameObject, temps);
    }
}

