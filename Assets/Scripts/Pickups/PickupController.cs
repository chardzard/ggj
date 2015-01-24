using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    public PowerupTypes type;

    public PowerupTypes Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }

}
