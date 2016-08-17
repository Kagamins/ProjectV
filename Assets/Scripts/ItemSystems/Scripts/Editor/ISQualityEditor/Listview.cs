using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace ProjectV.ItemSystem{
	public  partial class ISQualityDatabaseEditor  
	{

		//list all qualitys
		void ListView()
		{

			_scrollpos = EditorGUILayout.BeginScrollView (_scrollpos, GUILayout.ExpandHeight (true));

			DisplayQualities ();

			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth (true));
				BottomBar();
			GUILayout.EndHorizontal();
			EditorGUILayout.EndScrollView ();
		}

		void BottomBar ()
		{
			//Count
			GUILayout.Label ("Number of Qualities : " + db.Count.ToString ());
			//Add-Button
			if(GUILayout.Button("Add ")){
				db.Add(new ISQuality());

			}
		}
		void DisplayQualities()
		{

			for (int cnt = 0;cnt <db.Count; cnt++)
			{GUILayout.BeginHorizontal("Box");
				//sprite - Icon
				if(db.Get (cnt).Icon)
				{
					selectedtexture = db.Get (cnt).Icon.texture;
				}
				else
				{
					selectedtexture = null;
				}

				if (GUILayout.Button (selectedtexture, GUILayout.Width (SPRITE_BUTTON_SIZE), GUILayout.Height (SPRITE_BUTTON_SIZE)))
				{
						int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
						EditorGUIUtility.ShowObjectPicker<Sprite>( null, true, null,controlerID);
						selectedIndex = cnt;
				
				}
				string commandname = Event.current.commandName;
				if (commandname == "ObjectSelectorUpdated") 
				{
					if(selectedIndex != -1)
					{
					
					db.Get (selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
					
					selectedIndex = -1;
					}					
					Repaint();
				
				}

				GUILayout.BeginVertical();
				//name - name of the quality  item

				db.Get (cnt).Name = GUILayout.TextField(db.Get(cnt).Name);

				//Delete Button
				if(GUILayout.Button("X",GUILayout.Width(20)))
				{
					if(EditorUtility.DisplayDialog("Delete Quality",
					                               "Are you sure you want to Delete"+db.Get (cnt).Name+"From the Database",
					                               "Yes","No"))
					{

						db.Remove(cnt);
					}
				}
				GUILayout.EndVertical();
				GUILayout.EndHorizontal ();
			}
		}
	}
}
