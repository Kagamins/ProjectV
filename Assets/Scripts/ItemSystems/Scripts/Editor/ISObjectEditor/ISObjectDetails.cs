using UnityEngine;
using System.Collections;
using UnityEditor;
namespace ProjectV.ItemSystem{
public partial class  ISObjectCategory  {
		string stritemtype = "Armor"; 
		public void ItemDetails()
		{
			GUILayout.BeginVertical ("Box", GUILayout.ExpandWidth (true),GUILayout.ExpandHeight(true));
			GUILayout.BeginVertical ("Box", GUILayout.ExpandWidth (true),GUILayout.ExpandHeight(true));
			//StateMachine
			if (show_details) {
				temparmor.OnGUI ();
			}
			GUILayout.EndVertical ();
			GUILayout.Space (50);
			GUILayout.BeginHorizontal ( GUILayout.ExpandWidth (true));
			DisplayButtons ();
			GUILayout.EndHorizontal ();
			GUILayout.EndVertical ();
		}
		void DisplayButtons(){
			if (show_details) {
//				Debug.Log ("Show Item Details");
				SaveButton();
				DeleteButton();
				CancelButton();
			} 
			else
			{
				if(!show_details && !CreateNewArmor)
				{
				CreateItemButton ();
				}
				if(show_details&&CreateNewArmor)
				{
					SaveButton();
					CancelButton();
				}


			}
		}
		 void CreateItemButton()
		{

				if (GUILayout.Button ("Create " + stritemtype)) {
					temparmor = new ISArmor();
					show_details = true;
				CreateNewArmor = true;
					
				}
			}
		void SaveButton()
				{
			GUI.SetNextControlName("SaveButton");
			if (GUILayout.Button ("Save"))
			{
				
				
					string DATABASE_FILE_NAME = @"PVQualityDataBase.asset";
					string DATABASE_FOLDER_NAME = @"Database";
					
					ISQualityDatabase qdb;
					qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
					
					temparmor.Quality = qdb.Get (temparmor.SelectedQualityID);
							if (_selectedindex == -1)
								db.Add (temparmor);
							else {
								db.Replace (_selectedindex, temparmor);
							}
				temparmor = null;
				_selectedindex = -1;
				CreateNewArmor = false;
				show_details = false;
				GUI.FocusControl("SaveButton");	
		
			}

				}
			void CancelButton()
				{
			if(GUILayout.Button("Cancel"))
			{
				_selectedindex = -1;

				temparmor = null;
				show_details = false;
				CreateNewArmor = false;
				GUI.FocusControl("SaveButton");
			}


				}
		void DeleteButton()
		{
			
			if(_selectedindex != -1)
			{
				if(GUILayout.Button("Delete"))
				{
					
					if(EditorUtility.DisplayDialog("Delete Weapon",
					                               "Are you sure you want to Delete "+temparmor.Name+"From the Database",
					                               "Delete","Cancel")){
						db.Remove(_selectedindex);
						temparmor = null;
						_selectedindex = -1;
						show_details = false;
						CreateNewArmor = false;

						GUI.FocusControl("SaveButton");
					}
				}
			}

	
		}
	}
}

