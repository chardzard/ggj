using UnityEngine;
using System.Collections;

public class BulletLaser : Bullet {

    public Material startingMat;

    public float fadeTime;

    private LineRenderer lineRenderer;

    private float totalTime;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit))
        {
            lineRenderer.material = startingMat;
            lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

            if(hit.transform.tag == "Player")
            {
                PlayerHealthController health = hit.transform.GetComponent<PlayerHealthController>();
                health.Helth -= 35;
            }
            else if (hit.transform.tag == "Enemy")
            {
                AIController health = hit.transform.GetComponent<AIController>();
                health.health -= 35;
            }

            totalTime = 0f;
        }
    }

    public void Update()
    {
        totalTime += Time.deltaTime;
        float fadelv = totalTime / fadeTime;
        Color laserColor = Color.Lerp(Color.white, Color.clear, fadelv);
        lineRenderer.SetColors(laserColor, laserColor);
        if (fadelv >= 1f)
        {
            Destroy(gameObject);
        }
    }

    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_Shooter || other.gameObject.tag == "Bullet")
        {
            return;
        }
        if (other.tag == "Player")
        {
            PlayerHealthController hit = other.GetComponent<PlayerHealthController>();
            hit.Helth -= 3;
        }
        else if (other.tag == "Enemy")
        {
            AIController hit = other.GetComponent<AIController>();
            hit.health -= 3;
        }
        Destroy(gameObject);
    }
     * */
}

