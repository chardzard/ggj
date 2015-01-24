using UnityEngine;
using System;

public class BasicNav : MonoBehaviour {

    NavMeshAgent agent;
    GameObject[] pickups;
    GameObject[] enemies;
    GameObject player;

	void Start () 
    {
        agent = GetComponent<NavMeshAgent>();
        pickups = GameObject.FindGameObjectsWithTag("Pickup");
        enemies = GameObject.FindGameObjectsWithTag("OtherAI");
        player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () 
    {
        pickups = GameObject.FindGameObjectsWithTag("Pickup");
        enemies = GameObject.FindGameObjectsWithTag("OtherAI");
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject closestPickupObj = null;
        GameObject closestAI = null;
        if(pickups.Length > 0)
            closestPickupObj = closestObj(pickups);
        if(enemies.Length > 0)
            closestAI = closestObj(enemies);
        if (closestPickupObj != null)
        {
            agent.SetDestination(closestPickupObj.transform.position);
        }
        else if(closestAI != null)
        {
            agent.SetDestination(closestAI.transform.position);
        }
        else
        {
            agent.SetDestination(player.transform.position);
        }
	}
    GameObject closestObj(GameObject[] objects)
    {
        Vector3 closest = new Vector3(99999,99999,99999);
        GameObject closestObj = null;
        foreach(GameObject obj in objects){
            Vector3 current = obj.transform.position - agent.transform.position;
            if (current.magnitude < closest.magnitude)
            {
                closest = current;
                closestObj = obj;
            }
        }
        return closestObj;
    }
}
