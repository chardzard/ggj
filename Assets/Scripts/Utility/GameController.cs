using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text timeRemainingText;

    public float endTime;  // Minutes
    public int endKills; // Num kills

    public AudioClip normalMusic;
    public AudioClip lowMusic;

    private int[] killCount;
    private GameObject[] actorArray;
    private float startTime;

    private bool currentSong;

    public void actorKill(GameObject killer)
    {
        for (int i = 0; i < actorArray.Length; i++)
        {
            if( actorArray[i] == killer)
            {
                killCount[i]++;
                if(killCount[i] >= endKills )
                {
                    EndGame();
                }
                return;
            }
        }
        
    }

private void EndGame()
{
 	throw new System.NotImplementedException();
}

	// Use this for initialization
	void Start () {

        endTime *= 60f;
        endTime += Time.time; 
	}
	
	// Update is called once per frame
	void Update () {
        float secondsRemaining = endTime - Time.time;
        if (secondsRemaining >= 0f)
        {
            UpdateClock(secondsRemaining);
        }
        else
        {
            EndGame();
        }
	}

    void UpdateClock(float secondsRemaining)
    {
        int seconds = (int) secondsRemaining;
        timeRemainingText.text = seconds/60 + ":" + seconds%60;
    }

    internal void updateSong(bool p)
    {
        if(currentSong != p)
        {
            if(p)
            {
                audio.clip = lowMusic;
            }
            else
            {
                audio.clip = normalMusic;
            }
        }
        audio.Play();
    }
}
