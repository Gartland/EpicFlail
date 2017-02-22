using UnityEngine;
using System.Collections;

public class Flail : MonoBehaviour {

	Transform parent;
	Vector2 pos;
	bool holding = true;
	public GameObject flail;
	public GameObject sword;

	// Use this for initialization
	void Start ()
	{
		parent = transform.parent;
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GvrController.TouchDown)
			pos = GvrController.TouchPos;

		if (GvrController.TouchUp)
			HandleSwipe();
	}
	void SwitchToWeapon(GameObject wep1, GameObject wep2)
	{
		wep1.SetActive (false);
		wep2.SetActive (true);
	}

	void HandleSwipe()
	{
		if (GvrController.TouchPos.x < pos.x)
			SwitchToWeapon (flail, sword);
		if (GvrController.TouchPos.x > pos.x)
			SwitchToWeapon(sword,flail);
				
	}
}
