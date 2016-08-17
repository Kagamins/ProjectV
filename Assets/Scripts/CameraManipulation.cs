using UnityEngine;
using System.Collections;

public class CameraManipulation : MonoBehaviour {
	public GameObject Player;
	public Camera _Player_Cam,_MiniMap_Cam,_PauseMenuCam,_AircraftCam;
	public static  bool x = false;
	public static bool z = true;
	public static bool pause=false;
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		 
	}
	
 	void Update () {
		 
		if (Input.GetButtonDown ("Pause_Toggle")) {
			Time.timeScale = 0;
			pause = true;
			_Player_Cam.gameObject.SetActive (false);
			_MiniMap_Cam.gameObject.SetActive (false);
			_AircraftCam.gameObject.SetActive (false);
			_PauseMenuCam.gameObject.SetActive (true);
 
		}
 			if (pause) {
				_Player_Cam.gameObject.SetActive (false);
				_MiniMap_Cam.gameObject.SetActive (false);
				_AircraftCam.gameObject.SetActive (false);
				_PauseMenuCam.gameObject.SetActive (true);
				Time.timeScale = 0;

 		}

		if (!z) {
			if (x) {
				Time.timeScale = 1;
				_Player_Cam.gameObject.SetActive (false);
				_MiniMap_Cam.gameObject.SetActive (false);
				_AircraftCam.gameObject.SetActive (true);
				_PauseMenuCam.gameObject.SetActive (false);
			} else {
				Time.timeScale = 1;
				_Player_Cam.gameObject.SetActive (true);
				_MiniMap_Cam.gameObject.SetActive (true);
				_PauseMenuCam.gameObject.SetActive (false);
				_AircraftCam.gameObject.SetActive (false);
			}
		}
		 

		if (x) {
			Player.SetActive (false);
			_Player_Cam.gameObject.SetActive (false);
			_MiniMap_Cam.gameObject.SetActive (false);
			_AircraftCam.gameObject.SetActive (true);
			_PauseMenuCam.gameObject.SetActive (false);
		}
 			if (!x) {
//				Player.SetActive (true);
			if (!pause) {
				_Player_Cam.gameObject.SetActive (true);
				_MiniMap_Cam.gameObject.SetActive (true);
				_PauseMenuCam.gameObject.SetActive (false);
				_AircraftCam.gameObject.SetActive (false);
			}
 		}
	}
}
