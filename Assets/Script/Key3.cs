using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key3 : MonoBehaviour
{
    //on peut aller chercher des fonction dans d'autres codes
    public Player getKey;
    public bool PlayerHasKey3;





    public void Awake()
    {
        //getkey va aller chercher le GO dans le scrpt de playermovement
        getKey = GameObject.FindObjectOfType<Player>();
        PlayerHasKey3 = getKey.HasKey3;

        if (PlayerHasKey3 == true)
        {
            Destroy(this.gameObject);
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //on active la fonction du joueur, la key devient true
            collision.gameObject.GetComponent<Player>().GetKey3();
            Destroy(this.gameObject);
        }


    }


}