using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour {

    private Inventory inventory;

	public int health;
	public AbstractWeapon[] weaponPrefabs;
	private AbstractWeapon weapon;
	public Vector3 weaponOffsetPosition;
	public Quaternion weaponOffsetRotation;
    NavMeshAgent agent;
    List<GameObject> pickupList;
    List<GameObject> actorList;
    GameObject player;
    GameObject moveTarget;
    GameObject shootTarget;

	public float actorRotationSpeed;

	void Start () {
        inventory = GetComponent<Inventory>();
		weapon = Instantiate(weaponPrefabs[0], transform.position + weaponOffsetPosition, transform.rotation) as AbstractWeapon;
		weapon.transform.SetParent (transform, false);
        agent = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
        
        updateTargetLists();
        agent.updateRotation = false;   
     
        GameObject closestPickupObj = null;
        GameObject closestActor = null;

        if (pickupList.Count > 0)
            closestPickupObj = closestObj(pickupList);
        if (actorList.Count > 0)
            closestActor = closestObj(actorList);

        if (closestPickupObj != null)
        {
            moveTarget = closestPickupObj;
            Debug.Log("going to pickup");
        }
        if (closestActor != null)
        {
            shootTarget = closestActor;
            Debug.Log("going to enemy");
        }
        
        if(shootTarget != null)
            shootTargeting();
        if(moveTarget != null)
            agent.SetDestination(moveTarget.transform.position);

        if(health <= 0)
        {

        }
	}

    void updateTargetLists()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
        GameObject[] actors = GameObject.FindGameObjectsWithTag("Enemy");
        actorList = new List<GameObject>(actors);
        player = GameObject.FindGameObjectWithTag("Player");
        actorList.Add(player);
        pickupList = new List<GameObject>(pickups);
    }

    public void setInventoryWeapon(PowerupTypes type)
    {
        inventory.Attack = type;
    }

    public void setInventoryArmor(PowerupTypes type)
    {
        inventory.Defence = type;
    }

    GameObject closestObj(List<GameObject> objects)
    {
        Vector3 closest = new Vector3(999999, 999999, 999999);
        GameObject closestObj = null;
        foreach (GameObject obj in objects)
        {
            if (obj != gameObject)
            {
                Vector3 current = obj.transform.position - transform.position;
                if (current.magnitude < closest.magnitude)
                {
                    closest = current;
                    closestObj = obj;
                }
            }
        }
        return closestObj;
    }

    void shootTargeting()
    {
        Vector3 directionalDistance = shootTarget.transform.position - transform.position;
        if (directionalDistance.magnitude < weapon.SuggestedRange)
        {
            RaycastHit hitInfo;
            Debug.DrawRay(transform.position, directionalDistance, Color.red);
            bool castVal = Physics.Raycast(transform.position, directionalDistance, out hitInfo);
            //If we can see target, face to it
            if (hitInfo.transform != null && hitInfo.transform.gameObject == shootTarget)
            {
                Vector3 direction = directionalDistance.normalized;
                Debug.DrawRay(transform.position, direction, Color.blue);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * actorRotationSpeed);
                //Quaternion rotation = Quaternion.LookRotation(direction);
                //transform.rotation = rotation;

                if (weapon.CurrentAmmo > 0 && castVal)
                {
                    weapon.Fire(gameObject, transform.rotation, rigidbody.velocity);
                }
                else if (weapon.CurrentAmmo <= 0)
                {
                    //Swap back to default ammo
                }
            }
        }
    }
}
