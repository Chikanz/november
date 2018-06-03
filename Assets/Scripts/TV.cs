using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Interactable
{
    public GameObject PlaneOn;
    public GameObject PlaneOff;

    public AudioClip Switch;

    bool isOn = false;

    public override void Interact()
    {
        isOn = !isOn;        

        PlaneOff.SetActive(!isOn);
        PlaneOn.SetActive(isOn);

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(Switch);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
