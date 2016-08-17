using UnityEngine;
using System.Collections;

public class AirCraft : MonoBehaviour {
	public GameObject _Player;
	public GameObject _pod;
	//thruster particles 
	public GameObject _Front_Thruster,_Back_Thruster,_DownThruster;
	Transform _position;
	void Start () {
		_Player = GameObject.FindGameObjectWithTag ("Player");
		_position = transform;
	}
	
 	void Update () {
		if (CameraManipulation.x) {
			_Player.transform.position = new Vector3( _pod.transform.position.x,_pod.transform.position.y+12f,_pod.transform.position.z);
 		}
		if (Input.GetButtonDown ("Dismount")) {
			_Player.gameObject.SetActive (true);
			CameraManipulation.x = false;
		}
		if (CameraManipulation.x) {
			//Movement Commands Rotation
			if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0) {
				_position.Rotate (0, Input.GetAxis ("Horizontal") * Time.deltaTime * 40, 0);
			}
 			//Movement Commands Moving Forward  &Backward

			if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0) {
				_position.Translate (Vector3.back * Input.GetAxis ("Vertical") * Time.maximumDeltaTime * 0.3f);
				_Back_Thruster .SetActive (true);
			} else {
				_Back_Thruster.SetActive (false);

			}
			if (Mathf.Abs (Input.GetAxis ("Jump")) > 0) {
				_position.Translate (Vector3.up * Time.maximumDeltaTime * 0.3f);
				_DownThruster.SetActive (true);
			} else {
				_DownThruster.SetActive (false);
			}
			//Descending Command Going Down
			if (Mathf.Abs (Input.GetAxis ("Descend")) > 0) {
				_position.Translate (Vector3.down * 12 * Time.maximumDeltaTime * 0.03f);
				_DownThruster.SetActive (true);

			}
			else {
				_DownThruster.SetActive (false);
			}
		}
	}
	void OnMouseEnter(){
		PlayerUIManager.Mount = true;
 	}
	void OnMouseExit(){
		PlayerUIManager.Mount = false;
	}
 }
