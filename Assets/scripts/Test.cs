using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
		GetComponent<Text> ().text = PlayerPrefs.GetInt ("Uron") + "";
	}
}
