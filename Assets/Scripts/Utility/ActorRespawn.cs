using UnityEngine;
using System.Collections;

public class ActorRespawn : MonoBehaviour {

    public Vector3 location;

    void Start()
    {
        location = transform.position;
    }

}
