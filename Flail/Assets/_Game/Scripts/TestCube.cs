using UnityEngine;
using System.Collections;

public class TestCube : MonoBehaviour {

	void OnCollisionEnter(Collision hit)
	{
		GetComponent<Teleport> ().TeleportRandomly ();
	}

}
