using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour 
{
	public static float timeSpeed;
	public static float targetTS;

	public static void SetTimeScale (float num) 
	{
		targetTS = num;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.timeScale > targetTS) 
			Time.timeScale -= .1f;
		if (Time.timeScale < targetTS)
			Time.timeScale += .1f;
	}
}
