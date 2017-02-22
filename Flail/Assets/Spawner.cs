using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Spawner : MonoBehaviour 
{
	public GameObject player;
	public GameObject enemy;
	public Transform[] spawnPoints;

	public void Spawn(int count)
	{
		for (int i = 0; i < count; i++)
		{
			int spawnPtNumber = Random.Range (0, spawnPoints.Length);
			GameObject clone = (GameObject)Instantiate (enemy, spawnPoints [spawnPtNumber].position, spawnPoints [spawnPtNumber].localRotation);
			clone.GetComponent<AICharacterControl> ().target = player.transform;
			clone.GetComponent<Enemy> ().spawner = this;
		}
	}

	void Update () 
	{

		if (Input.GetKey ("s")) 
		{
			Spawn (1);
		}
	}
}
