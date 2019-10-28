using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SH : MonoBehaviour {

	int delay = 0, ScorS = 10, m = 1;
	GameObject a,b,c;
	public GameObject bullet, bullet2, bullet3, explosion;
	Rigidbody2D rb;
	public float speed;
	public int health=3;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		a=transform.Find("a").gameObject;
		b=transform.Find("b").gameObject;
		c=transform.Find("c").gameObject;
	}

	void Start(){
		PlayerPrefs.SetInt ("Health", health);
		ScorS = PlayerPrefs.GetInt ("ScorS");
		m = PlayerPrefs.GetInt ("M");
	}

	void Update () {
		rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed,0));
		rb.AddForce(new Vector2(0,Input.GetAxis("Vertical")*speed));

		if (Input.GetKey (KeyCode.Escape))
			SceneManager.LoadScene (0);


		if (Input.GetKey (KeyCode.Space)&&delay>ScorS)
			Shoot ();

		delay++;
	}

	public void Damage(){
		health--;
		PlayerPrefs.SetInt ("Health", health);
		StartCoroutine (Blink());
		if (health == 0) {
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (gameObject,0.1f);
		}
	}

	IEnumerator Blink(){
		GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
	}

	void Shoot(){
		delay = 0;
		if (m == 1) {
			Instantiate (bullet, c.transform.position, Quaternion.identity);
		}
		if (m == 2) {
			Instantiate (bullet, a.transform.position, Quaternion.identity);
			Instantiate (bullet, b.transform.position, Quaternion.identity);
		}
		if (m == 3) {
			Instantiate (bullet, a.transform.position, Quaternion.identity);
			Instantiate (bullet, b.transform.position, Quaternion.identity);
			Instantiate (bullet, c.transform.position, Quaternion.identity);
		}
		if (m == 5) {
			Instantiate (bullet, c.transform.position, Quaternion.identity);
			Instantiate (bullet2, a.transform.position, Quaternion.identity);
			Instantiate (bullet3, b.transform.position, Quaternion.identity);
		}
	}

	public void AddHealth(){
		health++;
		PlayerPrefs.SetInt ("Health", health);
	}
}
