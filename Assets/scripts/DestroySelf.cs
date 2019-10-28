using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	public float time;

	void Start () {
		Destroy (gameObject, time);
	}
}
