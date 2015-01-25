using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour {

    private Inventory inventory;

	public int health;
	public AbstractWeapon[] weaponPrefabs;
	public Vector3 weaponOffsetPosition;
	public Quaternion weaponOffsetRotation;
    public float actorRotationSpeed;
    public float aggroLevel;
    public float aggroDecrease;

    AbstractWeapon weapon;
    NavMeshAgent agent;
    List<GameObject> pickupList;
    List<GameObject> actorList;
    Dictionary<GameObject, float> aggroList;
    GameObject player;
    GameObject moveTarget;
    GameObject shootTarget;

	void Start () {
        inventory = GetComponent<Inventory>();
		weapon = Instantiate(weaponPrefabs[0], transform.position + weaponOffsetPosition, transform.rotation) as AbstractWeapon;
		weapon.transform.SetParent (transform, false);
        agent = GetComponent<NavMeshAgent>();
        aggroList = new Dictionary<GameObject, float>();
	}
	
	void Update () {
        
        updateTargetLists();
        agent.updateRotation = false;   
     
        GameObject closestPickupObj = null;
        GameObject closestActor = null;

        foreach(KeyValuePair<GameObject, float> entry in aggroList) 
        {
            if (aggroList[entry.Key] > 0)
                aggroList[entry.Key] -= aggroDecrease * Time.deltaTime;
        }
        updateShootingTarget();

        if (pickupList.Count > 0)
            closestPickupObj = closestObj(pickupList);
        /*if (actorList.Count > 0)
            closestActor = closestObj(actorList);*/

        if (closestPickupObj != null)
        {
            moveTarget = closestPickupObj;
            Debug.Log("going to pickup");
        }
        /*if (aggroList.Count == 0 && closestActor != null)
        {
            shootTarget = closestActor;
            Debug.Log("going to enemy");
        }*/
        
        if(shootTarget != null)
            shootAtTarget();
        if (moveTarget != null)
			moveToTarget ();

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

    void shootAtTarget() {
        Vector3 directionalDistance = shootTarget.transform.position - transform.position;
        if (directionalDistance.magnitude < weapon.SuggestedRange) {
            RaycastHit hitInfo;
            bool castVal = Physics.Raycast(transform.position, directionalDistance, out hitInfo);
            //If we can see target, face to it
            if (hitInfo.transform != null && hitInfo.transform.gameObject == shootTarget) {
                Vector3 direction = directionalDistance.normalized;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * actorRotationSpeed);

                if (weapon.CurrentAmmo > 0 && castVal && transform.rotation == Quaternion.LookRotation(direction)) {
                    weapon.Fire(gameObject, transform.rotation, rigidbody.velocity);
                }
            }
        }
    }
	void moveToTarget() {
		
		agent.SetDestination (moveTarget.transform.position);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Bullet hit = other.transform.GetComponentInParent<Bullet>();
            GameObject shooter = hit.m_Shooter;
            float temp = 0;
            if (aggroList.TryGetValue(shooter,out temp))
            {
                aggroList[shooter] += aggroLevel;
            }
            else
            {
                aggroList.Add(shooter, aggroLevel);
            }
        }
    }

    void updateShootingTarget()
    {
        GameObject highestAggro = null;
        float highestValue = 0;
        foreach (KeyValuePair<GameObject, float> entry in aggroList)
        {
            if (entry.Value > highestValue)
            {
                highestValue = entry.Value;
                highestAggro = entry.Key;
            }
        }
        if (highestAggro != null)
        {
            shootTarget = highestAggro;
        }
        else
        {
            shootTarget = closestObj(actorList);
        }
    }

    void addAggro(GameObject shooter, float damage)
    {
        float temp = 0;
        if (aggroList.TryGetValue(shooter, out temp))
        {
            aggroList[shooter] += (aggroLevel * damage);
        }
    }
}
