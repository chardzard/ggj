using UnityEngine;
using System.Collections;

public class PhysicsController : MonoBehaviour {

    public float gravity;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Physics.gravity = new Vector3(0f, gravity, 0f);
	}
}
