using UnityEngine;
using System.Collections;

public class ButtonController: MonoBehaviour 
{
	public Light lamp;
	public Light falseLamp;
	public Light point;

	public Light previousLamp;
	public bool previousNeeded;
	public bool finalLamp;

	public int timer;
	public int falseTime;
	public int fadeOut;

	// Use this for initialization
	void Start () 
	{
		lamp.enabled = false;
		falseLamp.enabled = false;
		point.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (falseLamp.enabled && (timer < falseTime))
		{
			timer++;
		}

		else if (falseLamp.enabled && (timer >= falseTime))
		{
			timer = 0;
			falseLamp.enabled = false;
		}

		if (finalLamp && lamp.enabled)
		{
			if (timer >= fadeOut)
			{
				Light[] lights = FindObjectsOfType(typeof(Light)) as Light[];

				foreach(Light light in lights)
				{
					light.intensity -= 1.0f / fadeOut;
				}
			}

			if (timer <= fadeOut)
			{
				timer++;
			}
		}
	}

	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.tag == "tool")
		{
			Debug.Log ("Pressed button");

			if (falseLamp.enabled)
			{
				falseLamp.enabled = false;
			}

			else
			{
				if (previousLamp.enabled == previousNeeded)
				{
					lamp.enabled = true;
					point.enabled = true;
				}
				
				else
				{
					falseLamp.enabled = true;
				}
			}
		}
	}
}
