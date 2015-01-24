using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    private Inventory inventory;

	public int health;
	public AbstractWeapon weaponPrefab;
	private AbstractWeapon weapon;
	GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
        inventory = GetComponent<Inventory>();
		weapon = Instantiate(weaponPrefab, transform.position + new Vector3(10, 0, -5), transform.rotation) as AbstractWeapon;
	}
	
	void Update () {
		//Test firing stuff - aim at player and shoot
		if ((transform.position - player.transform.position).magnitude < weapon.SuggestedRange) {
			weapon.Fire (gameObject);
		}
        if(health <= 0)
        {

        }
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Pickup")
        {
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
            Vector3 closest = new Vector3(99999, 99999, 99999);
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
            PickupController currentObj = other.GetComponent<PickupController>();
            Destroy(currentObj.gameObject);
            int weaponOrAmor = Random.Range(0, 2);
            if (weaponOrAmor == 0)
            {
                inventory.Attack = currentObj.type;
                Debug.Log("Attack " + inventory.Attack);
            }
            else
            {
                inventory.Defence = currentObj.type;
                Debug.Log("Defence " + inventory.Defence);
            }
        }
    }
}
