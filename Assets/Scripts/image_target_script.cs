using UnityEngine;
using System.Collections;
using Vuforia;

public class image_target_script : MonoBehaviour,ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;
	GameObject mangalyaan_super_container_GO;
	GameObject audio_mangalyaan;

	// Update is called once per frame
	void Update () {}

	void Start()
	{
		mangalyaan_super_container_GO = GameObject.Find ("mangalyaan_super_container");
		set_renderers_of_all_children_disabled_for_mangalyaan_super_container_GO ();

		audio_mangalyaan = GameObject.Find ("audio_mangalyaan_doc");
		//audio_mangalyaan.GetComponent<AudioSource> ().Stop ();


		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

	}

	void set_renderers_of_all_children_enabled_for_mangalyaan_super_container_GO(){
		Renderer[] component_array= mangalyaan_super_container_GO.GetComponentsInChildren<Renderer> ();
		for (int i = 0; i < component_array.Length; i++) {
			component_array [i].enabled = true;
		}
		//mangalyaan_super_container_GO.GetComponent<Renderer> ().enabled = false;
	}
	void set_renderers_of_all_children_disabled_for_mangalyaan_super_container_GO(){
		Renderer[] component_array= mangalyaan_super_container_GO.GetComponentsInChildren<Renderer> ();
		for (int i = 0; i < component_array.Length; i++) {
			component_array [i].enabled = false;
		}
		//mangalyaan_super_container_GO.GetComponent<Renderer> ().enabled = false;
	}


	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			if (previousStatus == TrackableBehaviour.Status.NOT_FOUND ||
			    previousStatus == TrackableBehaviour.Status.UNDEFINED ||
			    previousStatus == TrackableBehaviour.Status.UNKNOWN) 
			{				
				if (PlayerPrefs.GetInt ("sound_enable") == 1) {
					audio_mangalyaan.GetComponent<AudioSource> ().Play ();
				}
				set_renderers_of_all_children_enabled_for_mangalyaan_super_container_GO ();

			}
			// Play audio when target is found
			//audio.Play();
		}
		else
		{
			if (previousStatus == TrackableBehaviour.Status.DETECTED ||
			    previousStatus == TrackableBehaviour.Status.TRACKED ||
			    previousStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) 
			{
				set_renderers_of_all_children_disabled_for_mangalyaan_super_container_GO ();
				audio_mangalyaan.GetComponent<AudioSource> ().Stop ();
			}
		}
	}   
}