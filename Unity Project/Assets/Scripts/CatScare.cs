using UnityEngine;
using System.Collections;

public class CatScare : MonoBehaviour 
{
	public int scareTimer = 0;
	public int scareLimit = 30 * 60;
	public bool scare = false;

	public int lightTimer = 0;
	public int lightLimit = 5 * 60;
	public bool light = true;

	public GUIText text;
	public GUIText sleepText;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!light)
		{
			Light[] lights = FindObjectsOfType(typeof(Light)) as Light[];

			foreach (Light flashlight in lights)
			{
				if (flashlight.tag == "flashlight")
				{
					flashlight.enabled = false;
				}
			}
		}

		if (light)
		{
			Light[] lights = FindObjectsOfType(typeof(Light)) as Light[];
			
			foreach (Light flashlight in lights)
			{
				if (flashlight.tag == "flashlight")
				{
					flashlight.enabled = true;
				}
			}
		}

		if (!scare)
		{
			scareTimer++;

			if (scareTimer > scareLimit)
			{
				scare = true;
				renderer.enabled = true;
				light = false;
			}
		}

		if (scare && !light)
		{
			lightTimer++;

			if (lightTimer > lightLimit)
			{
				light = true;
				text.enabled = true;
				sleepText.text = "Thank you for playing - ESC to quit";
			}
		}
	}
}
