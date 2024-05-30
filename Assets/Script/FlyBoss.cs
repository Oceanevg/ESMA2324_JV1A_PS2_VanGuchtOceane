using UnityEngine;

public class FlyBoss : MonoBehaviour
{
    public GameObject PrefabBouleBoss;
    public Transform SpawnBouleBoss;
    public GameObject objectToDestroy;

    public float cooldown;

    public bool temps = true;



    private void Update()
    {
        if (temps == true)
        {
            temps = false;
            var bouleEnemy = Instantiate(PrefabBouleBoss, SpawnBouleBoss.position, SpawnBouleBoss.rotation);
            Invoke("cdChange", cooldown);
        }
    }


    public void cdChange()
    {
        temps = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Projectile"))
        {
            Destroy(objectToDestroy);
        }
    }
}