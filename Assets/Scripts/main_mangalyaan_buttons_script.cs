using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;

public class main_mangalyaan_buttons_script : MonoBehaviour {
	GameObject flashlight;
	GameObject flip_camera;
	GameObject takesnap;
	bool flashLightEnabled;
	// Use this for initialization
	void Start () {
		flashlight = GameObject.Find ("Canvas/flashlight");

		autoFocus ();
		flashLightEnabled = false;
		checkFlashlight ();
//		checkCamera ();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void autoFocus(){
		bool auto_focus_enabled = CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}

	public void toggleFlashlight(){
		flashLightEnabled = !flashLightEnabled;
		bool flashLightAvailable = CameraDevice.Instance.SetFlashTorchMode (flashLightEnabled);
	}

	void checkFlashlight(){
		bool flashLightAvailable = CameraDevice.Instance.SetFlashTorchMode(false);
		if (!flashLightAvailable) {
			flashlight.GetComponent<Button> ().interactable = false;
		}
	}

//	void checkCamera(){
//		CameraDevice.Instance.Stop ();
//		CameraDevice.Instance.Deinit ();
//		Debug.Log ("  CAMERA OFF NOW ");
//		bool dualCamera = CameraDevice.Instance.Init (CameraDevice.CameraDirection.CAMERA_FRONT);
//		Debug.Log (" CAMERA SHOULD HAVE RESTARTED NOW - VALUE OF BOOL = "+dualCamera);
//		if (!dualCamera) {
//			Debug.Log ("DAMN, CAMERA IS A WEBCAMERA !");
//		}
//	}

	public void toggleCamera(){
		CameraDevice.CameraDirection cam_direc = CameraDevice.Instance.GetCameraDirection ();
		if (cam_direc == CameraDevice.CameraDirection.CAMERA_DEFAULT || cam_direc == CameraDevice.CameraDirection.CAMERA_BACK) {
			restartCamera (CameraDevice.CameraDirection.CAMERA_FRONT);
		} else {
			restartCamera (CameraDevice.CameraDirection.CAMERA_BACK);
		}
	}

	void restartCamera ( CameraDevice.CameraDirection direction){
		CameraDevice.Instance.Stop ();
		CameraDevice.Instance.Deinit ();
		CameraDevice.Instance.Init (direction);
		CameraDevice.Instance.Start ();
	}

	public void refocusCamera(){
		bool auto_focus_enabled = CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
	}
}
