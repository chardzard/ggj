using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    public PowerupTypes type;

    void OnTriggerEnter(Collider other)
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
        }
        else if (other.gameObject.tag == "PlayerController")
        {
            //TODO functionality for players picking up powerup
        }
        spawnTimer();
        Destroy(gameObject);
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
