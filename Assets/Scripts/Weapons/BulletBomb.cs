using UnityEngine;
using System.Collections;

public class BulletBomb : Bullet {

    public float m_Force;

    public GameObject exploasion;

    void Start()
    {
        rigidbody.velocity += transform.forward * m_Force;
        StartCoroutine(DestroyForTime());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_Shooter)
        {
            return;
        }
        Instantiate(exploasion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Update()
    {

    }

    private IEnumerator DestroyForTime()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}