using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour 
{
	public bool fading;
	public bool faded;
	public int fadeTimer;
	private int fadeLimit = 180;
	private float fadeIncrement = 1 / 180.0f;

	// Use this for initialization
	void Start () 
	{
		fadeTimer = 0;
		faded = false;
		fading = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!fading)
		{
			fadeTimer++;

			if (fadeTimer > fadeLimit)
			{
				fadeTimer = 0;
				fading = true;
			}
		}

		else if (!faded && fading)
		{
			renderer.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, renderer.material.color.a - fadeIncrement));
		
			if (renderer.material.color.a <= 0.01f)
			{
				faded = true;
				fading = false;
			}
		}

		else if (faded && fading)
		{
			renderer.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, renderer.material.color.a + fadeIncrement));

			if (renderer.material.color.a >= 0.99f)
			{
				faded = false;
				fading = false;
			}
		}

	}
}
