using UnityEngine;
using System.Collections;

public class VinSavePoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			SaveInformation.Save ();
			Debug.Log("You Just Hit a Checkpoint");
			DestroyObject(transform.gameObject);
		}


	}
}
