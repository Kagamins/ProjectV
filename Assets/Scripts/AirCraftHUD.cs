using UnityEngine;
using System.Collections;

public class AirCraftHUD : MonoBehaviour {
	public GameObject _player,_pod;
	public Texture _Left,_Right;
	public Rect _LeftRect, _RightRect;

 	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player");
		_Left =Resources.Load("Textures/HUD/LeftSide") as Texture;
		_Right =Resources.Load("Textures/HUD/RightSide") as Texture;
		_RightRect = new Rect (Screen.width-Screen.width/5,Screen.height/2,Screen.width/5,Screen.height/2);
		_LeftRect = new Rect (0,Screen.height/2,Screen.width/5,Screen.height/2);

	}
	void OnGUI(){
		GUI.DrawTexture (_LeftRect,_Left);
		GUI.DrawTexture (_RightRect,_Right);
		GUI.Label (new Rect(Screen.width/2,Screen.height/2-Screen.height/6,320,40),"To Dismount The Vehicle press the z Button","Box");
		 

	}
 	void Update () {
		
		_RightRect = new Rect (Screen.width-Screen.width/5,Screen.height/2,Screen.width/5,Screen.height/2);
		_LeftRect = new Rect (0,Screen.height/2,Screen.width/5,Screen.height/2);
	}

}
