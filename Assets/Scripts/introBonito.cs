using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class IntroBonito : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject FPS;
    public GameObject FakeWall;
    public GameObject Door;

    public Interactable Lamp;

    // Use this for initialization
    void Start ()
    {        
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

        if (DoorCamera.loopNum == 2)
        {
            Invoke("Run",5);
        }
        
    }

    //End game
    private void Run()
    {
        Canvas.SetActive(true);
        FPS.GetComponent<FirstPersonController>().m_WalkSpeed = 10;
        Invoke("ToggleCanvasOff", 0.5f);
        FakeWall.transform.Translate(-2.7f,0,0);
        Door.SetActive(false);
    }

    private void ToggleCanvasOff()
    {
        Canvas.SetActive(false);
    }
    

    void ToggleObjects(bool on)
    {        
        FPS.SetActive(on);
        GetComponent<Camera>().enabled = !on;
        gameObject.SetActive(!on);
    }

    public void ToggleLamp()
    {
        Lamp.Interact();
    }
}
