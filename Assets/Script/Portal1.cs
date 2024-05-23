using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal1 : MonoBehaviour
{
    public string SceneName;
    public bool CheckKey1;
    public Player Key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Key = GameObject.FindObjectOfType<Player>();
            CheckKey1 = Key.HasKey1;

            if (CheckKey1 == true)
            {
                SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
            }
        }
    }
}