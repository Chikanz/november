using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {

    public Vector2 RandomRange;

    public AudioClip[] Clips;   
	
	void Start ()
    {
        QueueSound();
    }

    void PlaySound()
    {
        //Get random child, play random clip
        transform.GetChild(Random.Range(0,transform.childCount)).
            GetComponent<AudioSource>().PlayOneShot(Clips[Random.Range(0, Clips.Length)]);
        
        QueueSound();
    }

    void QueueSound()
    {
        Invoke("PlaySound", Random.Range((int)RandomRange.x, (int)RandomRange.y));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
