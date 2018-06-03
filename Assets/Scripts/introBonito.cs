using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introBonito : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject FPS;

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
        ToggleObjects(true);
    }

    void ToggleObjects(bool on)
    {
        Canvas.SetActive(!on);
        FPS.SetActive(on);
        GetComponent<Camera>().enabled = !on;
    }
}
