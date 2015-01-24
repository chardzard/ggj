using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    GameObject agent;
    public int health;
    private Inventory inventory;
	GameObject player;
	AbstractWeapon weapon;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
        inventory = GetComponent<Inventory>();
		//weapon = Instantiate(new BasicWeapon(), transform.position + new Vector3(10, 0, -5), transform.rotation) as AbstractWeapon;
	}
	
	void Update () {
		//Test firing stuff - aim at player and shoot
	/*	if ((transform.position - player.transform.position).magnitude < weapon.SuggestedRange) {
			weapon.Fire(gameObject);
		}*/
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
