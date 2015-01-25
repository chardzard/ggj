using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {

    public float maxSize = 4.69f;

    public int steps;

    private SphereCollider damageRadius;

    public void Start()
    {
        damageRadius = GetComponent<SphereCollider>();
        StartCoroutine(Expand());
        StartCoroutine(DestroyForTime());
    }

    public IEnumerator Expand()
    {
        float stepSize = maxSize / steps;
        for (int i = 0; i < steps; i++)
        {
            damageRadius.radius += stepSize;
            yield return new WaitForEndOfFrame();
        }
        damageRadius.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController hit = other.GetComponent<PlayerHealthController>();
            hit.Helth -= 25;
        }
        else if (other.tag == "Enemy")
        {
            AIController hit = other.GetComponent<AIController>();
            hit.health -= 25;
        }
    }

    private IEnumerator DestroyForTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
