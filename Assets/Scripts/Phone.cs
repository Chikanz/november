using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactable
{
    public GameObject reciever;
    public AudioClip Pickup;
    public AudioClip Tone;
    public AudioClip Putdown;

    bool pickedUp = false;

    AudioSource myAudio;

    public override void Interact()
    {
        if(!pickedUp)
        {
            pickedUp = true;
            reciever.SetActive(false);
            myAudio.Stop(); //Stop ringing

            myAudio.PlayOneShot(Pickup);

            Invoke("playTone", 0.5f);
        }
        else
        {
            reciever.SetActive(true);
            pickedUp = false;
            myAudio.Stop();
            myAudio.PlayOneShot(Putdown);
        }
    }

   void playTone()
    {
        myAudio.clip = Tone;
        myAudio.Play();
    }

    // Use this for initialization
    void Start ()
    {
        myAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
