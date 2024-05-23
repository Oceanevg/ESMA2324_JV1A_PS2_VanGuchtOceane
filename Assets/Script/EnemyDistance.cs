using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : MonoBehaviour
{
    public GameObject PrefabBouleEnemy;
    public Transform SpawnBoule;
    
    public float cooldown;

    public bool temps = true;



    private void Update()
    {
        if (temps == true)
        {
            temps = false;
            var bouleEnemy = Instantiate(PrefabBouleEnemy, SpawnBoule.position, SpawnBoule.rotation);
            Invoke("cdChange", cooldown);
        }
    }


    public void cdChange()
    {
        temps = true;
    }
}
