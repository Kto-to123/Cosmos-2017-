using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonFonctions : MonoBehaviour {

	public void Quit(){
		Application.Quit ();
	}

	public void Start(){
		PlayerPrefs.SetInt ("Score", 0);
		SceneManager.LoadScene(1);
	}

	public void Magazin(){
		SceneManager.LoadScene(2);
	}

	public void Vozvrat(){
		SceneManager.LoadScene(0);
	}

	public void Sbros(){
		PlayerPrefs.SetInt ("ScorS", 10);
		PlayerPrefs.SetInt ("Uron", 1);
		PlayerPrefs.SetInt ("M", 1);
	}

	public void Uron(){
		PlayerPrefs.SetInt ("Uron", PlayerPrefs.GetInt ("Uron") + 1);
	}

	public void ScorS(){
		if (PlayerPrefs.GetInt ("ScorS") > 1) {
			PlayerPrefs.SetInt ("ScorS", PlayerPrefs.GetInt ("ScorS") - 1);
		}
	}

	public void M1(){
		PlayerPrefs.SetInt ("M", 1);
		PlayerPrefs.SetInt ("ScorS", 10);
	}

	public void M2(){
		PlayerPrefs.SetInt ("M", 2);
		PlayerPrefs.SetInt ("ScorS", 10);
	}

	public void M3(){
		PlayerPrefs.SetInt ("M", 3);
		PlayerPrefs.SetInt ("ScorS", 10);
	}

	public void M4(){
		PlayerPrefs.SetInt ("M", 1);
		PlayerPrefs.SetInt ("ScorS", 5);
	}

	public void M5(){
		PlayerPrefs.SetInt ("M", 5);
		PlayerPrefs.SetInt ("ScorS", 10);
	}
}
