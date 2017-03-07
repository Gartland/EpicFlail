//James Gartland 5/7/2016

using UnityEngine;
using System.Collections;

public class SoundTest : MonoBehaviour {

	public Light myLight;		//light to change
	public float baseVal;		//base value for modified float
	public float multi;			//multiplier set to sample data
	public int refreshRate;		//how often to change float

	float[] samples;			//array of audio samples
	AudioSource myAudio;		//this GameObject's audio
	int refreshTimer = 0;

	public float currentSample;
	float prevSample;

	void Start()
	{
		myAudio = GetComponent<AudioSource> ();

		samples = new float[myAudio.clip.samples * myAudio.clip.channels];

		myAudio.clip.GetData (samples, 0);
	}

	void Update()
	{
		refreshTimer += 1;

		currentSample = samples [myAudio.timeSamples];

		if (refreshTimer > refreshRate) 
		{
			myLight.intensity = (baseVal + (currentSample + prevSample)/2) * multi;
			refreshTimer = 0;
		}

		prevSample = currentSample;
	}
}

