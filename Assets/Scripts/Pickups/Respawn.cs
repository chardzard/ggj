using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public float respawnTimer;
    public GameObject[] pickup;
    private bool timerStarted;
    private float reset;

    void Start()
    {
        timerStarted = false;
        int type = Random.Range(0, pickup.Length);
        Instantiate(pickup[type], transform.position + Vector3.up * .5f, Quaternion.identity);
    }

    void Update()
    {
        if (timerStarted)
        {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                timerStarted = false;
                respawnTimer = reset;
                int type = Random.Range(0, pickup.Length);
                Instantiate(pickup[type],transform.position + Vector3.up * .5f,Quaternion.identity);
            }
        }
    }

    public void startTimer()
    {
        reset = respawnTimer;
        timerStarted = true;
    }
}
