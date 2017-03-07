using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour {

	public Spawner spawner;
	public bool stunned;

	public Rigidbody[] joints;

	Animator anim;
	public int health = 3;

	bool dead = false;

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
		dead = true;
		anim.enabled = false;
		GetComponent<CapsuleCollider> ().enabled = false;
		GetComponent<NavMeshAgent> ().enabled = false;
		foreach (Rigidbody j in joints) 
		{
			j.isKinematic = false;
			j.gameObject.GetComponent<Collider> ().isTrigger = false;
		}
		spawner.Spawn (Random.Range(1,2));
	}
	void OnCollisionEnter (Collision hit) 
	{
		if (hit.gameObject.tag == "Mace" && !stunned) TakeDamage ();
	}
	void TakeDamage()
	{
		health--;
		if (health <= 0 && !dead) Die ();
		stunned = true;
		anim.SetTrigger ("Hit");
	}
	void Update()
	{
		//if (health <= 0) Die ();
		if (Vector3.Distance(transform.position, spawner.player.transform.position) < 3) Attack();
		anim.speed = Time.timeScale;
	}


}
