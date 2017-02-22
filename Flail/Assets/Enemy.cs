using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour {

	public Spawner spawner;
	public bool stunned;

	Animator anim;
	int health = 3;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}
	void Attack()
	{
		GetComponent<AICharacterControl> ().target = transform;
		anim.SetBool ("Attacking", true);
	}
	void Die () 
	{
		anim.SetTrigger ("Dead");
		//gameObject.SetActive (false);
		spawner.Spawn (Random.Range(1,2));
	}
	void OnCollisionEnter (Collision hit) 
	{
		if (hit.gameObject.tag == "Mace" && !stunned) TakeDamage ();
	}
	void TakeDamage()
	{
		health--;
		if (health <= 0) Die ();
		stunned = true;
		anim.SetTrigger ("Hit");
	}
	void Update()
	{
		if (Vector3.Distance(transform.position, spawner.player.transform.position) < 3) Attack();
	}


}
