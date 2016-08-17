//using UnityEngine;
//using System.Collections;
//using UnityEditor;
//
//
//namespace ProjectV.ItemSystem.Backup{
//public  partial class ISQualityDatabaseEditor : EditorWindow {
//
//		ISQualityDatabase db;
//		ISQuality selecteditem;
//		Texture2D selectedtexture;
//		int selectedIndex = -1;
//
//		Vector2 _scrollpos; //for the ListView
//
//		const int SPRITE_BUTTON_SIZE = 46;
//		const string DATABASE_FILE_NAME = @"PVQualityDataBase.asset";
//		const string DATABASE_FOLDER_NAME = @"Database";
//		const string DATABASE_PATH = @"Assets/" + DATABASE_FOLDER_NAME + "/"+DATABASE_FILE_NAME;
//
//
//		[MenuItem("PV/Database/Quality Editor %#i")]
//		public static void init(){
//			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor> ();
//			window.minSize = new Vector2 (400, 300);
//			window.title="Quality Database";
//			window.Show ();
//		}
//		void OnEnable()
//		{db = AssetDatabase.LoadAssetAtPath (DATABASE_PATH, typeof(ISQualityDatabase))as ISQualityDatabase;
//			if (db == null){
//			if (!AssetDatabase.IsValidFolder ("Assets/"+DATABASE_FOLDER_NAME)) 
//			
//				AssetDatabase.CreateFolder("Assets",DATABASE_FOLDER_NAME);
//								
//			db = ScriptableObject.CreateInstance<ISQualityDatabase> ();
//			AssetDatabase.CreateAsset (db, DATABASE_PATH);
//			AssetDatabase.SaveAssets ();
//			AssetDatabase.Refresh();
//				
//			}
//			selecteditem = new ISQuality ();
//		}
//		void OnGUI()
//		{
//			ListView ();
////			AddQualityToDatabase ();
//		}
//		void AddQualityToDatabase()
//		{
//			//name
//		
//			selecteditem.Name = EditorGUILayout.TextField ("Name:", selecteditem.Name);
//			//sprite
//			if (selecteditem.Icon)
//				selectedtexture = selecteditem.Icon.texture;
//			else 
//				selectedtexture = null;
//			if (GUILayout.Button (selectedtexture, GUILayout.Width (SPRITE_BUTTON_SIZE), GUILayout.Height (SPRITE_BUTTON_SIZE))) 
//			{
//				int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
//				EditorGUIUtility.ShowObjectPicker<Sprite>(null,true,null,controlerID);
//			}
//			string commandname = Event.current.commandName;
//			if (commandname == "ObjectSelectorUpdated") {
//				selecteditem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
//				Repaint();
//			}
//			if (GUILayout.Button ("Save")) {
//				if (selecteditem == null) 
//					return;
//				if(selecteditem.Name =="")
//					return;
//				//int x = db.Count;
//				db.Add (selecteditem);
//				//db.db.Add(selecteditem);
//				selecteditem = new ISQuality();
//				
//			}
//		}
//	}
//}