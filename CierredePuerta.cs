using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CierredePuerta : MonoBehaviour
{
	public GameObject puerta;
	SpawnEnemigos spawn;
	private void Start()
	{
		spawn = FindObjectOfType<SpawnEnemigos>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			spawn.startGame = true;
		}
	}
}
