using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {


	[System.Serializable]
	public class MoveSettings
	{
		public float forwardvel = 5f;
		public float rotatevel = 100f;
		public float jumpvel = 20f;
		public float disToGrounded = 0.1f;
		public LayerMask ground;
	}


	[System.Serializable]
	public class PhysSettings
	{
		public float downaccel = 0.76f;
	}


	[System.Serializable]
	public class InputSettings
	{
		public float inputdelay = 0.1f;
		public string FORWARD_AXIS = "Vertical";
		public string TURN_AXIS = "Horizontal";
		public string JUMP_AXIS = "Jump";
	}

	public MoveSettings moveSetting = new MoveSettings();

	public PhysSettings physSetting = new PhysSettings();

	public InputSettings inputSetting = new InputSettings();

	Vector3 velocity = Vector3.zero;
	Quaternion targetrotation;
	Rigidbody rbody;
	float forwardinput, turninput, jumpinput;
	public Quaternion TargetRotation
	{
		get {return targetrotation;  }

}
	bool Grounded(){
		return Physics.Raycast (transform.position, Vector3.down, moveSetting.disToGrounded, moveSetting.ground);
	
	}
	void Start(){

		targetrotation = transform.rotation;
		if (GetComponent<Rigidbody> ())
			rbody = GetComponent<Rigidbody> ();
		else
			Debug.LogError ("The Character does not have a RigidBody");
		forwardinput = turninput = jumpinput = 0f;
}
	void GetInput() {
		forwardinput = Input.GetAxis (inputSetting.FORWARD_AXIS);
		turninput = Input.GetAxis (inputSetting.TURN_AXIS);
		jumpinput = Input.GetAxisRaw (inputSetting.JUMP_AXIS);
}
	void Update(){
		GetInput ();
		Turn ();
	}
	void FixedUpdate(){
		Run ();
		Jump ();
		rbody.velocity = transform.TransformDirection(velocity);

	}
	void Run (){
		if (Mathf.Abs (forwardinput) > inputSetting.inputdelay) {
			//Movement
			velocity.z = moveSetting.forwardvel * forwardinput;
		}
		else 
			//Stopping
			velocity.z = 0;
					
	}
	void Turn(){
		if (Mathf.Abs (turninput) > inputSetting.inputdelay) {
			targetrotation *= Quaternion.AngleAxis (moveSetting.rotatevel * turninput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetrotation;
	
	}
	void Jump(){
		if (jumpinput > 0f && Grounded ()) {
			//jump
			velocity.y = moveSetting.jumpvel;
		} else if (jumpinput == 0f && Grounded ()) {
			//stay on the ground
			velocity.y = 0f;
		} else {
			//falling down 
			velocity.y -= physSetting.downaccel;
		}
		}
}