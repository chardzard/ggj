using UnityEngine;
using System.Collections;

public class PhysicsController : MonoBehaviour {

    public float gravity;

	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0f, gravity, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
