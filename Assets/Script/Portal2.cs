using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    public string SceneName;
    public bool CheckKey3;
    public Player Key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Key = GameObject.FindObjectOfType<Player>();
            CheckKey3 = Key.HasKey1;

            if (CheckKey3 == true)
            {
                SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
            }
        }
    }
}