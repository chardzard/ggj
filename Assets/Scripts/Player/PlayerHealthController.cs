using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour {

    public Slider healthSlider;
    public int maxHealth;

    public int Helth
    {
        get
        {
            return currentHelth;
        }
        set
        {
            currentHelth = value;
            UpdateHealth();
        }
    }

    private int currentHelth;

	// Use this for initialization
	void Start () {
        healthSlider.maxValue = maxHealth;
        currentHelth = maxHealth;
        UpdateHealth();
	}

    void UpdateHealth()
    {
        healthSlider.value = currentHelth;
        if(currentHelth <= 0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        throw new System.NotImplementedException();
    }
	
}
