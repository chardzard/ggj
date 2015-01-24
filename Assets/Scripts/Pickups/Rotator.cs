using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public float rotationRate;
    Vector3 rotate;
    void Start()
    {
        rotate = new Vector3(0, rotationRate * 45, 0);
    }
	void Update () 
    {
        transform.Rotate(rotate * Time.deltaTime);
	}
}
