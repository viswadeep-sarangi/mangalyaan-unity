using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class credits_page_script : MonoBehaviour {
	GameObject credits_page_text;

	// Use this for initialization
	void Start () {
		credits_page_text = GameObject.Find ("Canvas/Panel/Text");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			credits_page_text.GetComponent<Text> ().text = "Loading...Please Wait";
			SceneManager.LoadScene ("scene_start_menu");
		}

	}

	public void open_URL(string url){
		Application.OpenURL (url);
	}



}
