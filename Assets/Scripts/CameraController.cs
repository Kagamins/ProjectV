using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public Transform target;
	public float looksmooth = 0.09f;
	public Vector3 offsetfromtarget = new Vector3( 0 , 6 , -8);
	public float xtilt = 10f;

	Vector3 destination = Vector3.zero;
	CharacterController charcontroller;
	float rotatevel = 0f;

	void Start(){
		SetCameraTarget (target);

	}
	void SetCameraTarget(Transform t){
		target = t;
		if (target != null) {
			if (target.GetComponent<CharacterController> ()) {
				charcontroller = target.GetComponent<CharacterController> ();
			}
			else
				Debug.LogError("Your target needs a character controller");
		
		} else 
			Debug.LogError ("Your Camera needs a Target!!.");
		

	}
	void LateUpdate(){
		//moving 
		MoveToTarget ();
		//rotating
		LookAtTaget ();

	}
	void MoveToTarget(){
		destination = charcontroller.TargetRotation * offsetfromtarget;
		destination += target.position;
		transform.position = destination;

	}
	void LookAtTaget(){
		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y, target.eulerAngles.y, ref rotatevel, looksmooth);
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x, eulerYAngle, 0 );

	}
}

