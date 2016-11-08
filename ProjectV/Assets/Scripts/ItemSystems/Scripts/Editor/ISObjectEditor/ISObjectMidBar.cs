using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
	public  partial class ISObjectEditor   {
		void BottomBar(){
			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth (true));
			GUILayout.Label ("BottomBar");
			GUILayout.EndHorizontal ();
		}
	}
}