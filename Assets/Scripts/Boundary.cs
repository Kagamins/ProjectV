using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {
	public Transform _respawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag == "Player" ) {
			other.transform.position = new Vector3(_respawn.position.x,_respawn.position.y,_respawn.position.z);
			
		}
	}
}
