using UnityEngine;
using System.Collections;
using UnityEditor;


namespace ProjectV.ItemSystem{
public  partial class ISQualityDatabaseEditor : EditorWindow {

		ISQualityDatabase db;
		ISQuality selecteditem;
		Texture2D selectedtexture;
		int selectedIndex = -1;

		Vector2 _scrollpos; //for the ListView

		const int SPRITE_BUTTON_SIZE = 46;
		const string DATABASE_FILE_NAME = @"PVQualityDataBase.asset";
		const string DATABASE_FOLDER_NAME = @"Resources";
		const string DATABASE_PATH = @"Assets/" + DATABASE_FOLDER_NAME + "/"+DATABASE_FILE_NAME;


		[MenuItem("PV/Database/Quality Editor %#q")]
		public static void init(){
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor> ();
			window.minSize = new Vector2 (400, 300);
			window.titleContent.text="Quality Database";
			window.Show ();
		}
		void OnEnable()
		{
			//db = ScriptableObject.CreateInstance<ISQualityDatabase> ();
			if (db == null)
			{
				db = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
			}

		}
		void OnGUI()
		{
			ListView ();

		}
	

	}
}