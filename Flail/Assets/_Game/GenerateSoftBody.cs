using UnityEngine;
using System.Collections;
using UnityEditor;

public class GenerateSoftBody : MonoBehaviour {

	[MenuItem ("StupidDoll/BindStupidDoll")]
	static void BindDoll()
	{
		if (Selection.gameObjects.Length != 2)
		{
			Debug.LogError ("Not enough objects selected");
		}

		Debug.LogError (Selection.gameObjects [0].name + " is child");

		CharacterJoint[] parentJoints = Selection.gameObjects [1].GetComponentsInChildren<CharacterJoint> ();
		CharacterJoint[] childJoints = Selection.gameObjects [0].GetComponentsInChildren<CharacterJoint> ();

		foreach (Rigidbody rb in Selection.gameObjects [0].GetComponentsInChildren<Rigidbody>())
			rb.isKinematic = false;
			

		for (int i = 0; i < childJoints.Length; i++)
		{
			SpringJoint spring = childJoints [i].gameObject.AddComponent<SpringJoint> ();
			spring.spring = 10000f;
			spring.connectedBody = parentJoints[i].GetComponent<Rigidbody>();
		}
	}
}
