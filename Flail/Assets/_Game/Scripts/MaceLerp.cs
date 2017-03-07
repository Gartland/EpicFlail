using UnityEngine;
using System.Collections;

public class MaceLerp : MonoBehaviour {

	public Transform target;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.Lerp (transform.position, target.position, Time.deltaTime * speed); 
	}
}
