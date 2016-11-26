using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class functions_to_be_called : MonoBehaviour {
	GameObject sound_button_gameobject;
	Text t;
	// Use this for initialization
	void Start () {
		sound_button_gameobject = GameObject.Find ("Canvas/sound_button");
		t = sound_button_gameobject.GetComponentInChildren<Text> ();
		PlayerPrefs.SetInt ("sound_enable", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load_scene(string level_name){
		SceneManager.LoadScene (level_name);
	}

	public void toggle_sound(){
		if (PlayerPrefs.GetInt ("sound_enable", 1) == 1) {
			PlayerPrefs.SetInt ("sound_enable", 0);
			t.text = "SOUND : OFF";
			Debug.Log ("Sound is now Disabled");
		} else {
			PlayerPrefs.SetInt ("sound_enable", 1);
			t.text = "SOUND : ON";
			Debug.Log ("Sound is now Enabled");
		}
	}

	public void exit_app(){
		Application.Quit ();
	}
}
