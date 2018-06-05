using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : Interactable
{
    public AudioClip Switch;
    public AudioClip CryingStatic;

    public GameObject Knob;

    public override void Interact()
    {
        IsOn = !IsOn;

        if (IsOn)
            MyAudio.Play();
        else
            MyAudio.Stop();

        MyAudio.PlayOneShot(Switch);

        Knob.transform.rotation = Quaternion.Euler(IsOn ? -87 : 0, Knob.transform.eulerAngles.y, Knob.transform.eulerAngles.z);
    }

    // Use this for initialization
    void Start ()
    {
        base.Start();
        MyAudio = GetComponent<AudioSource>();        
    }

    protected override void OnLevelEnd(int i)
    {
        base.OnLevelEnd(i);
        if (i == 1) MyAudio.clip = CryingStatic;
    }

    // Update is called once per frame
	void Update () {
		
	}
}
