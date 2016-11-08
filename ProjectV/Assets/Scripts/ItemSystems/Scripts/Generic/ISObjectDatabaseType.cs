using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace ProjectV.ItemSystem{
	public partial class ISObjectDatabaseType<D,T> where D:ScriptableObjectDatabase<T> where T:ISObject,new() {
	public string stritemtype = ""; 

		[SerializeField] D db; //Database
		[SerializeField]string dbName; //DBName
		[SerializeField]string dbPath = @"Resources";

		public ISObjectDatabaseType(string n )
		{
			dbName = n + ".asset";
		}
#if UNITY_EDITOR
		public void OnEnable(string itype)
		{
			stritemtype = itype;
			if (db == null) 
			{

				LoadDatabase();
			}
//			CreateDatabase ();

		}

		public void OnGUI(Vector2 BtnSize)
		{
			ListView (BtnSize);
			ItemDetails();
		}
#endif
	}
	}
