using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;

namespace ProjectV.ItemSystem{
	public partial class ISObjectDatabaseType<D,T> where D:ScriptableObjectDatabase<T> where T:ISObject,new() {

		public void ItemDetails()
		{
			GUILayout.BeginVertical ("Box", GUILayout.ExpandWidth (true),GUILayout.ExpandHeight(true));
			GUILayout.BeginVertical ("Box", GUILayout.ExpandWidth (true),GUILayout.ExpandHeight(true));
			//StateMachine
			if (show_details) {
				tempItem.OnGUI ();
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
				if(!show_details && !CreateNewItem)
				{
				CreateItemButton ();
				}
				if(show_details&&CreateNewItem)
				{
					SaveButton();
					CancelButton();
				}


			}
		}
		 void CreateItemButton()
		{

				if (GUILayout.Button ("Create " + stritemtype)) {
				tempItem = new T();
					show_details = true;
				CreateNewItem = true;
					
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
					
				tempItem.Quality = qdb.Get (tempItem.SelectedQualityID);
							if (_selectedindex == -1)
					Add (tempItem);
							else {
					Replace (_selectedindex, tempItem);
							}
				tempItem = null;
				_selectedindex = -1;
				CreateNewItem = false;
				show_details = false;
				GUI.FocusControl("SaveButton");	
		
			}

				}
			void CancelButton()
				{
			if(GUILayout.Button("Cancel"))
			{
				_selectedindex = -1;

				tempItem = null;
				show_details = false;
				CreateNewItem = false;
				GUI.FocusControl("SaveButton");
			}


				}
		void DeleteButton()
		{
			
			if(_selectedindex != -1)
			{
				if(GUILayout.Button("Delete"))
				{
					
					if(EditorUtility.DisplayDialog("Delete "+ stritemtype,
					                               "Are you sure you want to Delete "+tempItem.Name+"From the Database",
					                               "Delete","Cancel")){
						Remove(_selectedindex);
						tempItem = null;
						_selectedindex = -1;
						show_details = false;
						CreateNewItem = false;

						GUI.FocusControl("SaveButton");
					}
				}
			}

	
		}
	}
}
#endif
