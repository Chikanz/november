using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtMoon : MonoBehaviour
{
	public Transform Moon;
	public GameObject WhiteCanvas;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		var v = Moon.position - transform.position;
		if (Vector3.Dot(v.normalized, transform.forward) > 0.8f)
		{
			WhiteCanvas.SetActive(true);
		}
	}
}
