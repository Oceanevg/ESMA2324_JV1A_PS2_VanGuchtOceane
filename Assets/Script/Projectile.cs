using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float spawn;
    public float temps;

    private GameObject player;
    private GameObject launch;
    private Rigidbody2D rb;

    


    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        launch = GameObject.FindGameObjectWithTag("Launch");

       
        //gameObject sans maj pour nous meme, sinon player c'est pour la fonction player, et le GameObject avec maj c'est pour aller chercher ailleurs jcrois
        Physics2D.IgnoreCollision(player.GetComponent <Collider2D>(), gameObject.GetComponent<Collider2D>());
        rb = gameObject.GetComponent<Rigidbody2D>();

        
        rb.velocity = (launch.transform.position - player.transform.position).normalized * speed;
        
        temps = spawn;

    }

    private void Update()
    {
        if (temps > 0f)
        {
            temps -= Time.deltaTime;

            if (temps < 0f)
            {
                Destroy(gameObject);
            }
        }
        Debug.Log(rb.velocity.x);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        
    }

}
