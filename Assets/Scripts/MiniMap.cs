using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {
	public Transform Target;
	public Camera MiniMapCam;


	void LateUpdate () {
		 
		transform.position = new Vector3 (Target.transform.position.x,Target.transform.position.y+39.5f,Target.transform.position.z);
	}
	void OnGUI(){
		 
			
			GUILayout.BeginArea (new Rect (Screen.width / 2 * 1.5f, 15, Screen.width / 16, Screen.height / 9));
			if (GUILayout.Button ("+")) {
				MiniMapCam.orthographicSize -= 10; 
		
			}

			if (GUILayout.Button ("-")) {
				MiniMapCam.orthographicSize += 10; 
		
			}
			GUILayout.EndArea ();
		}

}
