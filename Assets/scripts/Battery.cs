//Аптечки
using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<SH> ().AddHealth ();
			Destroy (gameObject);
		}
	}
}
