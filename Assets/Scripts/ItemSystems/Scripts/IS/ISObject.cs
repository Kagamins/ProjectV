using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace ProjectV.ItemSystem
{
	[System.Serializable]
public  class ISObject : IISObject {
		[SerializeField]Sprite _icon;
		[SerializeField]string _name;
		[SerializeField]int _value;
		[SerializeField]int _burden;
		[SerializeField]ISQuality _quality;


		public ISObject(){}


		public ISObject(ISObject item)
		{
			Clone (item);
		}
		public void Clone(ISObject item)
		{
			_name = item.Name;
			_icon = item.ISIcon;
			_quality = item.Quality;
			_burden = item.ISBurden;
			_value = item.ISValue;
		}
	public string Name {
		get {return _name;
			
		}
		set {_name = value;
			
		}
	}

	public int ISValue {
		get {return _value;
			
		}
		set {_value = value;
			
		}
	}

	public Sprite ISIcon {
		get {return _icon;
			
		}
		set {_icon=value;
			
		}
	}

	public int ISBurden {
		get {return _burden;
			
		}
		set {_burden = value;
			
		}
	}

	public ISQuality Quality {
		get {return _quality;
			
		}
		set {_quality = value;
			
		}

	}
		// this is gonna be placed in a new class
#if UNITY_EDITOR

		bool QDBLoaded = false;
		public int SelectedQualityID{get{return qualitySelectedIndex;}}
		ISQualityDatabase qdb;
		int qualitySelectedIndex = 0;
		string[] options;

		public virtual void OnGUI()
		{
			GUILayout.BeginVertical ();
			_name = EditorGUILayout.TextField ("Name", _name);
			_value = EditorGUILayout.IntField ("Value", _value );
			_burden = EditorGUILayout.IntField ("Burden", _burden);
			DisplayIcon ();
			DisplayQuality ();
			GUILayout.EndVertical ();
		}

		public void DisplayIcon()
		{
			_icon = EditorGUILayout.ObjectField ("Icon",_icon,typeof(Sprite),false)as Sprite;
		}


		public void LoadQualityDataBase()
		{
			 string DATABASE_FILE_NAME = @"PVQualityDataBase.asset";
			 string DATABASE_FOLDER_NAME = @"Database";
			qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
			options = new string[qdb.Count];
			for (int cnt =0; cnt<qdb.Count; cnt++)
				options [cnt] = qdb.Get (cnt).Name;
			QDBLoaded = true;
		}


		public void DisplayQuality()
		{
			if (!QDBLoaded) 
			{
				LoadQualityDataBase();
				return;
			}
			int itemindex = 0;

			if(_quality !=null)
				 itemindex = qdb.GetIndex (_quality.Name);

			if (itemindex == -1)
				itemindex = 0;
		qualitySelectedIndex =	EditorGUILayout.Popup ("Quality", itemindex, options);
//			_quality = qdb.Get (SelectedQualityID);
		}
#endif

}
}
