using UnityEngine;
using System.Collections;

public class BulletNone : MonoBehaviour {

    public float m_Force;

	void Start () {
        rigidbody.AddForce(transform.forward * m_Force);
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

        }
        else if(other.tag == "Enemy")
        {

        }
        Destroy(gameObject);
    }
}
