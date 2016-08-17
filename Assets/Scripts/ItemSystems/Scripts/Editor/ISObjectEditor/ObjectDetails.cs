using UnityEngine;
using System.Collections;
using UnityEditor;
namespace ProjectV.ItemSystem{
	public  partial class ISObjectEditor   {
		enum DisplayState
		{
			NONE,
			DETAILS
		};
//
//		ISWeapon tempweapon = new ISWeapon();
//		bool show_weapon_details = false;
//		DisplayState state = DisplayState.NONE; 
//		void ObjectDetails()
//		{
//			GUILayout.BeginVertical ("Box", GUILayout.ExpandWidth (true),GUILayout.ExpandHeight(true));
//			GUILayout.BeginVertical ("Box", GUILayout.ExpandWidth (true),GUILayout.ExpandHeight(true));
//			switch (state) 
//			{
//			case DisplayState.DETAILS:
//				if(show_weapon_details)
//					DisplayNewWeapon ();
//				break;
//			default:
//				break;
//
//			}
//
//
//
//			GUILayout.EndVertical ();
//			GUILayout.Space (50);
//			GUILayout.BeginHorizontal ( GUILayout.ExpandWidth (true));
//			DisplayButtons ();
//			GUILayout.EndHorizontal ();
//			GUILayout.EndVertical ();
//		}
//		void DisplayNewWeapon()
//		{
//			GUILayout.BeginVertical ();
//			tempweapon.OnGUI ();
//			GUILayout.EndVertical ();
//		}
//
//		void DisplayButtons()
//		{
//			if (!show_weapon_details) {
//				if (GUILayout.Button ("Create")) {
//					tempweapon = new ISWeapon();
//					show_weapon_details = true;
//					state = DisplayState.DETAILS;
//			
//				}
//			}
//				else
//			{GUI.SetNextControlName("SaveButton");
//					if(GUILayout.Button("Save"))
//					{
//						
//
//					string DATABASE_FILE_NAME = @"PVQualityDataBase.asset";
//					string DATABASE_FOLDER_NAME = @"Database";
//
//					ISQualityDatabase qdb;
//					qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
//
//					tempweapon.Quality = qdb.Get(tempweapon.SelectedQualityID);
//						if(_selectedindex == -1)
//							wdb.Add (tempweapon);
//						else
//					{wdb.Replace(_selectedindex,tempweapon);}
//					tempweapon = null;
//					_selectedindex = -1;
//					state = DisplayState.NONE;
//					show_weapon_details = false;
//
//					GUI.FocusControl("SaveButton");
//
//					}
//				if(_selectedindex != -1)
//				{
//					if(GUILayout.Button("Delete"))
//				{
//
//						if(EditorUtility.DisplayDialog("Delete Weapon",
//						                               "Are you sure you want to Delete "+wdb.Get (_selectedindex).Name+"From the Database",
//						                               "Delete","Cancel")){
//							wdb.Remove(_selectedindex);
//							tempweapon = null;
//							_selectedindex = -1;
//							show_weapon_details = false;
//							state = DisplayState.NONE;
//							GUI.FocusControl("SaveButton");
//						}
//				}
//				}
//					if(GUILayout.Button("Cancel"))
//					{
//						_selectedindex = -1;
//						show_weapon_details = false;
//						tempweapon = null;
//						state = DisplayState.NONE;
//					GUI.FocusControl("SaveButton");
//					}
//				}
//
//		}
//
	
	}
}