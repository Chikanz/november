using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : Interactable
{
    bool isOn = false;

    public AudioClip Switch;

    AudioSource myAudio;

    public GameObject Knob;

    public override void Interact()
    {
        isOn = !isOn;

        if (isOn)
            myAudio.Play();
        else
            myAudio.Stop();

        myAudio.PlayOneShot(Switch);

        Knob.transform.rotation = Quaternion.Euler(isOn ? -87 : 0, Knob.transform.eulerAngles.y, Knob.transform.eulerAngles.z);
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
