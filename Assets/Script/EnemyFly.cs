using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToDestroy;

    public float speed;
    public float distanceBetween;

    private float distance;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        // prends la distance entre les deux fonctions et va le retourner dans la fonction distance
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        //On normalise la direction, ça va garder la direction et garder la longueur à 1
        direction.Normalize();
        //fonction pour trouver l'angle entre 2 points
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //on transforme de radian à degrés


        //Code pour que l'ennemi nous chasse seulement quand on est à une certaines distance
        if (distance < distanceBetween)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            //L'ennemi va aller vers la position donnée (le joueur)
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Projectile"))
        {
            Destroy(objectToDestroy);
        }
    }
}
