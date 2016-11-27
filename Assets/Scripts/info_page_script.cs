using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class info_page_script : MonoBehaviour {
	GameObject loading_text;
	GameObject hide_because_of_loading;

	// Use this for initialization
	void Start () {
		loading_text = GameObject.Find ("Canvas/Panel_text");
		hide_because_of_loading = GameObject.Find ("Canvas/Panel");
		change_renderer_status (loading_text, false);
		change_renderer_status (hide_because_of_loading, true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			change_renderer_status (hide_because_of_loading, false);
			change_renderer_status (loading_text, true);
			SceneManager.LoadScene ("scene_start_menu");
		}
	
	}

	public void open_URL(string url){
		Application.OpenURL (url);
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

}
