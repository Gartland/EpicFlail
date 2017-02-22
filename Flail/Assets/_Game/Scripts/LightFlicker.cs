using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	public Vector2 range;

	Light myLight;

	void Start()
	{
		myLight = GetComponent<Light> ();
	}
	// Update is called once per frame
	void Update () 
	{
		myLight.intensity = Random.Range (range.x, range.y);
	}
}
