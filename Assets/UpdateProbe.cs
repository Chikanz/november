using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateProbe : MonoBehaviour
{
	public static event EventHandler OnLightChanged;
	
	// Use this for initialization
	void Start()
	{
		OnLightChanged += OnOnLightChanged;
	}


	// Update is called once per frame
	void Update()
	{
	}

	private void OnOnLightChanged(object sender, EventArgs e)
	{
		GetComponent<ReflectionProbe>().RenderProbe();
	}

	//good method name is good lol
	public static void OnOnLightChanged()
	{
		var handler = OnLightChanged;
		if (handler != null) handler(null, EventArgs.Empty);
	}
}
