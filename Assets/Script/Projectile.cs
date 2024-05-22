using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 4.5f;


    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
