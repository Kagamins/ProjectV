using UnityEngine;
using System.Collections;

public class MainMenuCommands : MonoBehaviour
{
	public string LevelName;
	private string Something;
	public Rect WindowSize = new Rect (Screen.height/2, Screen.width/2, 250, 250);
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI(){
		
		//GUI.Window(0,WindowSize,MyWindow,"MainMenu");
		Something = GUILayout.TextField ("Type",30);
		if (GUILayout.Button ("NewGame")) {
			Application.LoadLevel("SchoolLevel");
		}
	}

	private void MyWindow(int id){
		Something = GUILayout.TextField ("Type",30);
		

		GUI.DragWindow ();
	}
	

}

