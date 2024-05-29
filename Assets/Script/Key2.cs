using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier1 : MonoBehaviour
{
    //on peut aller chercher des fonction dans d'autres codes
    public Player getKey;
    public bool PlayerHasKey2;

    public GameObject door;


    public void Awake()
    {
        getKey = GameObject.FindObjectOfType<Player>();
        PlayerHasKey2 = getKey.HasKey2;

        if (PlayerHasKey2 == true)
        {
            Destroy(door);
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            //on active la fonction du joueur, la key devient true
            collision.gameObject.GetComponent<Player>().GetKey2();
            Destroy(door);
        }
    }


}
