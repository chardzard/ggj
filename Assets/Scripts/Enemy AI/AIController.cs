using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    private Inventory inventory;

	public int health;
	public AbstractWeapon[] weaponPrefabs;
	private AbstractWeapon weapon;
	public Vector3 weaponOffsetPosition;
	public Quaternion weaponOffsetRotation;

	public float actorRotationSpeed;
	GameObject target;

	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
        inventory = GetComponent<Inventory>();
		weapon = Instantiate(weaponPrefabs[0], transform.position + weaponOffsetPosition, transform.rotation) as AbstractWeapon;
		weapon.transform.SetParent (transform, false);
	}
	
	void Update () {
		//Test firing stuff - aim at player and shoot
		Vector3 directionalDistance = target.transform.position - transform.position;
		if (directionalDistance.magnitude < weapon.SuggestedRange) {
			RaycastHit hitInfo;
			Debug.DrawRay (transform.position, directionalDistance, Color.red);
			bool castVal = Physics.Raycast(transform.position, directionalDistance, out hitInfo);
			//If we can see target, face to it
			if (hitInfo.transform != null && hitInfo.transform.gameObject == target) {
				Vector3 direction = directionalDistance.normalized;
				Debug.DrawRay (transform.position, direction, Color.blue);
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * actorRotationSpeed);
				//Quaternion rotation = Quaternion.LookRotation(direction);
				//transform.rotation = rotation;

				if (weapon.CurrentAmmo > 0 && castVal) {
					weapon.Fire (gameObject, transform.rotation, rigidbody.velocity);
				} else if (weapon.CurrentAmmo <= 0) {
					//Swap back to default ammo
				}
			}
		}
        if(health <= 0)
        {

        }
	}

    public void setInventoryWeapon(PowerupTypes type)
    {
        inventory.Attack = type;
    }

    public void setInventoryArmor(PowerupTypes type)
    {
        inventory.Defence = type;
    }
}
