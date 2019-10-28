using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour {

	Rigidbody2D rb;
	int dir=1;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}

	public void ChangeDirection () {
		dir*=-1;
	}

	public void ChangeColor(Color col){
		GetComponent<SpriteRenderer>().color=col;
	}

	void Update () {
		rb.velocity = new Vector2 (4,12*dir);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (dir == 1) { 
			if (col.gameObject.tag == "Vrag") {
				col.gameObject.GetComponent<Vrag> ().Damage ();
				Destroy (gameObject);
			}
		} else {
			if (col.gameObject.tag == "Player") {
				col.gameObject.GetComponent<SH> ().Damage ();
				Destroy (gameObject);
			}
		}
	}
}
