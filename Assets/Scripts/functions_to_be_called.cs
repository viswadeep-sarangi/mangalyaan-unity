using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class functions_to_be_called : MonoBehaviour {
	GameObject sound_button_gameobject;
	GameObject audio_start_page;
	Text t;

	GameObject loading_text;
	GameObject hide_because_of_loading;

	// Use this for initialization
	void Start () {
		sound_button_gameobject = GameObject.Find ("Canvas/Panel/sound_button");
		t = sound_button_gameobject.GetComponentInChildren<Text> ();
		//PlayerPrefs.SetInt ("sound_enable", 1);
		audio_start_page = GameObject.Find ("start_page_audio");
		//audio_start_page.GetComponent<AudioSource> ().Play ();

		loading_text = GameObject.Find ("Canvas/panel_loading_text");
		hide_because_of_loading = GameObject.Find ("Canvas/Panel");

		Debug.Log ("loading text=" + loading_text.GetComponentsInChildren<CanvasRenderer> ().Length + 
			" - panel to disappear=" + hide_because_of_loading.GetComponentsInChildren<CanvasRenderer> ().Length);

		change_renderer_status (loading_text, false);
		change_renderer_status (hide_because_of_loading, true);

		//checking sound
		check_sound();
		tutorial_note_check ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load_scene(string level_name){
		change_renderer_status (hide_because_of_loading, false);
		change_renderer_status (loading_text, true);
		SceneManager.LoadScene (level_name);
	}

	public void toggle_sound(){
		if (PlayerPrefs.GetInt ("sound_enable", 1) == 1) {
			PlayerPrefs.SetInt ("sound_enable", 0);
			audio_start_page.GetComponent<AudioSource> ().Pause ();
			t.text = "SOUND : OFF";
			Debug.Log ("Sound is now Disabled");
		} else {
			PlayerPrefs.SetInt ("sound_enable", 1);
			audio_start_page.GetComponent<AudioSource> ().Play ();
			t.text = "SOUND : ON";
			Debug.Log ("Sound is now Enabled");
		}
	}

	public void check_sound(){
		if (PlayerPrefs.GetInt ("sound_enable", 1) == 1) {
			audio_start_page.GetComponent<AudioSource> ().Play ();
			t.text = "SOUND : ON";
			Debug.Log ("Sound is now Enabled");
		} else {
			audio_start_page.GetComponent<AudioSource> ().Pause ();
			t.text = "SOUND : OFF";
			Debug.Log ("Sound is now Disabled");
		}
	}

	public void exit_app(){
		Application.Quit ();
	}

	void change_renderer_status(GameObject go, bool status){
		CanvasRenderer[] renderer_array = go.GetComponentsInChildren<CanvasRenderer> ();
		for (int i = 0; i < renderer_array.Length; i++) {
			if (status){
				renderer_array [i].SetAlpha (1.0f);
			}else{
				renderer_array [i].SetAlpha (0.0f);
			}
		}
	}

	void tutorial_note_check(){
		GameObject tut_text = GameObject.Find ("Canvas/Panel/note");
		if (PlayerPrefs.GetInt ("first_time", 1) == 1) {			
			change_renderer_status (tut_text, true);
			PlayerPrefs.SetInt ("first_time", 0);
		} else {
			change_renderer_status (tut_text, false);
		}
	}
}