using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public int waves=1;
	public float rate;
	public GameObject[] enemies;

	void Start () {
		InvokeRepeating("SpawnEnemy",rate,rate);
	}

	void SpawnEnemy () {
		for (int i = 0; i < waves; i++) {
			Instantiate (enemies [(int)Random.Range (0, enemies.Length)], new Vector3 (Random.Range (-8.5f, 8.5f), 7, 0), Quaternion.identity);	
		}
	}

}
