﻿using UnityEngine;
using System.Collections;

public class BulletNone : Bullet {

    public float m_Force;

	void Start () {
        rigidbody.AddForce(transform.forward * m_Force);
        StartCoroutine(DestroyForTime());
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_Shooter)
        {
            return;
        }
        if(other.tag == "Player")
        {

        }
        else if(other.tag == "Enemy")
        {

        }
        Destroy(gameObject);
    }

    private IEnumerator DestroyForTime()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
