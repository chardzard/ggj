using UnityEngine;
using System.Collections;

public class BulletNone : Bullet {

    public float m_Force;

	void Start () {
        rigidbody.velocity += transform.forward * m_Force;
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
            PlayerHealthController hit = other.GetComponent<PlayerHealthController>();
            hit.Helth -= 5;
        }
        else if(other.tag == "Enemy")
        {
            AIController hit = other.GetComponent<AIController>();
            hit.health -= 5;
        }
        Destroy(gameObject);
    }

    private IEnumerator DestroyForTime()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
