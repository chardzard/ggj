using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    private Inventory inventory;

	public int health;
	public AbstractWeapon[] weaponPrefabs;
	private AbstractWeapon weapon;
	public Vector3 weaponOffsetPosition;
	public Quaternion weaponOffsetRotation;
	public GameObject agent;
	GameObject target;

	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
        inventory = GetComponent<Inventory>();
		weapon = Instantiate(weaponPrefabs[0], transform.position + weaponOffsetPosition, transform.rotation) as AbstractWeapon;
		weapon.transform.SetParent (transform, false);
	}
	
	void Update () {
		//Test firing stuff - aim at player and shoot
		Vector3 directionalDistance = transform.position - target.transform.position;
		if (directionalDistance.magnitude < weapon.SuggestedRange) {
			/*RaycastHit hitInfo;
			Physics.Raycast(transform.position, directionalDistance, out hitInfo);
			//If we can see target, face to it
			if (hitInfo.rigidbody.gameObject == target) {
				transform.Rotate (*/


			if(weapon.CurrentAmmo > 0) {
				weapon.Fire (gameObject);
			} else if (weapon.CurrentAmmo <= 0) {
				//Swap back to default ammo
			}
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
                Vector3 currentPos = obj.transform.position - agent.transform.position;
                if (currentPos.magnitude < closest.magnitude)
                {
                    closest = currentPos;
                    closestSpawn = obj;
                }
            }
            Respawn spawn = closestSpawn.GetComponent<Respawn>();
            spawn.startTimer();
            PickupController currentObj = other.GetComponent<PickupController>();
            currentObj.gameObject.SetActive(false);
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
