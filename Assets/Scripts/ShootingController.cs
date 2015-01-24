using UnityEngine;
using System.Collections;

public class ShootingController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButton("Fire1"))
        {
            FireWeapon();
        }
	}

    void FireWeapon()
    {
 
    }
}
