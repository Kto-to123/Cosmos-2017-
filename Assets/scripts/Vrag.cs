using UnityEngine;
using System.Collections;

public class Vrag : MonoBehaviour {

	Rigidbody2D rb;
	public GameObject bullet, explosion, battery;
	public Color bulletcolor;

	public float xSpeed, ySpeed;
	public int score;
	int Uron;

	public bool canShoot;
	public float fireRate;
	public float health;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		Uron = PlayerPrefs.GetInt ("Uron");
		PlayerPrefs.SetInt ("Uron2", Uron);
		if (!canShoot) { return; }
		fireRate = fireRate + (Random.Range (fireRate / -2, fireRate / 2));
		InvokeRepeating ("Shoot", fireRate, fireRate);
	}

	void Update () {
		rb.velocity = new Vector2 (xSpeed,ySpeed*-1);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<SH> ().Damage ();
			Die ();
		}
	}

	void Die(){
		if ((int)Random.Range (0, 3) == 0) {
			Instantiate (battery, transform.position, Quaternion.identity);
		}
		Instantiate (explosion, transform.position, Quaternion.identity);
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score")+score);
		Destroy (gameObject);
	}

	public void Damage(){
		if (Uron > 1) { health--; }
		if (Uron > 2) { health--; }
		if (Uron > 3) { health--; }
		health--;
		
		//StartCoroutine (Blink());
		if (health <= 0)
			Die ();
	}

	IEnumerator Blink(){
		GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
		yield return new WaitForSeconds (0.2f);
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
	}

	void Shoot(){
		GameObject temp = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
		temp.GetComponent<Bullet> ().ChangeDirection ();
		temp.GetComponent<Bullet>().ChangeColor(bulletcolor);
	}
}
