using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    GameObject agent;
    public int health;
    private Inventory inventory;

	void Start () {
        inventory = GetComponent<Inventory>();
	}
	
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        PickupController current = other.GetComponent<PickupController>();
        int weaponOrAmor = Random.Range(0, 2);
        if (weaponOrAmor == 0)
        {
            inventory.Attack = current.type;
            Debug.Log("Attack " + inventory.Attack);
        }
        else
        {
            inventory.Defence = current.type;
            Debug.Log("Defence " + inventory.Defence);
        }
    }
}
