using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    public PowerupTypes type;

    public AbstractWeapon weaponPrefabs;

    void OnTriggerEnter(Collider other)
    {
        bool used = false;
        if (type == PowerupTypes.shield)
        {
            if (other.gameObject.tag == "Enemy")
            {
                AIController enemy = other.GetComponent<AIController>();
                enemy.health = 100;
                used = true;
            }
            else if (other.gameObject.tag == "Player")
            {
                PlayerHealthController player = other.GetComponent<PlayerHealthController>();
                player.Helth = player.maxHealth;
                used = true;
            }
        }
        else
        {
            if (other.gameObject.tag == "Enemy")
            {
                AIController enemy = other.GetComponent<AIController>();
                int weaponOrAmor = Random.Range(0, 2);
                if (weaponOrAmor == 0)
                {
                    enemy.setInventoryWeapon(type);
                }
                else
                {
                    enemy.setInventoryArmor(type);
                }
                used = true;
            }
            else if (other.gameObject.tag == "Player")
            {
                PlayerShootingController player = other.GetComponent<PlayerShootingController>();
                player.WeaponUpdate(weaponPrefabs);
                used = true;
            }
        }
        if (used)
        {
            spawnTimer();
            Destroy(gameObject);
        }
    }

    void spawnTimer()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        Vector3 closest = spawners[0].transform.position;
        GameObject closestSpawn = null;
        foreach (GameObject obj in spawners)
        {
            Vector3 currentPos = obj.transform.position - transform.position;
            if (currentPos.magnitude < closest.magnitude)
            {
                closest = currentPos;
                closestSpawn = obj;
            }
        }
        Respawn spawn = closestSpawn.GetComponent<Respawn>();
        spawn.startTimer();
    }
}
