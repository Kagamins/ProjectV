using UnityEngine;
using System.Collections;

public class cubix : MonoBehaviour {
	public Animator x;
	void Awake(){
		x = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)){
		x.Play ("C_C",-1,0f);
		}
	}
}
