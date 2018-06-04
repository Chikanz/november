using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IntroBonito : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject FPS;

    public Interactable Lamp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResettiTheSpaghetti()
    {
        ToggleObjects(false);
    }

    /// <summary>
    /// Called on animation event
    /// </summary>
    public void EndOfIntro()
    {
        if(!EditorApplication.isPlaying) return;
        
        ToggleObjects(true);
    }

    void ToggleObjects(bool on)
    {
        if(Canvas) Destroy(Canvas);
        FPS.SetActive(on);
        GetComponent<Camera>().enabled = !on;
        gameObject.SetActive(!on);
    }

    public void ToggleLamp()
    {
        Lamp.Interact();
    }
}
