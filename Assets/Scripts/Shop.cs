using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
	Renderer _renderer;
	void Start () {
		_renderer = GetComponent<Renderer> ();
	}
	
	void OnMouseEnter(){
		PlayerUIManager._Aim = true;
	}
	void OnMouseExit(){
		PlayerUIManager._Aim = false;
	}
	void Update () {
	
	}

}
