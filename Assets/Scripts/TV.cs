using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Interactable
{
    public GameObject PlaneOn;
    public GameObject PlaneOff;

    public AudioClip Switch;

    public override void Interact()
    {
        isOn = !isOn;        

        PlaneOff.SetActive(!isOn);
        PlaneOn.SetActive(isOn);

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().PlayOneShot(Switch,1);
    }
}
