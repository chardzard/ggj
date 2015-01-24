using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

    private PowerupTypes attack;

    private PowerupTypes defence;

    public PowerupTypes Attack 
    {
        get
        {
            return attack;
        } 
        set
        {
            attack = value;
        }
    }

    public PowerupTypes Defence
    {
        get
        {
            return defence;
        }
        set
        {
            defence = value;
        }
    }
}
