using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    GameObject agent;
    public int health;
	GameObject player;
	AbstractWeapon weapon;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		//weapon = Instantiate(new BasicWeapon(), transform.position + new Vector3(10, 0, -5), transform.rotation) as AbstractWeapon;
	}
	
	void Update () {
		//Test firing stuff - aim at player and shoot
	/*	if ((transform.position - player.transform.position).magnitude < weapon.SuggestedRange) {
			weapon.Fire(gameObject);
		}*/
	}
}
