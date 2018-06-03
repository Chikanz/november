using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public GameObject[] Lights;
    public AudioClip SwitchClip;

    public Transform SwitchObj;

    public bool isOn = false;

    public override void Interact()
    {
        isOn = !isOn;
        ToggleLights(isOn);

        GetComponent<AudioSource>().PlayOneShot(SwitchClip);

        SwitchObj.rotation = Quaternion.Euler(isOn ? 80 : 0, SwitchObj.eulerAngles.y, SwitchObj.eulerAngles.z);
    }

    public void ToggleLights(bool on)
    {
        foreach (GameObject g in Lights)
        {
            g.SetActive(on);
        }
    }

    // Use this for initialization
    void Start ()
    {
        ToggleLights(isOn);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
