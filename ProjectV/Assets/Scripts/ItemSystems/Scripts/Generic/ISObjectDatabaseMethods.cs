using UnityEngine;
using System.Collections;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace ProjectV.ItemSystem{
	public partial class ISObjectDatabaseType<D,T> where D:ScriptableObjectDatabase<T> where T:ISObject,new() {


#if UNITY_EDITOR
		public void Add(T item)
		{
			db.Item.Add (item);
			EditorUtility.SetDirty (db);
		}
		
		public void Insert(int index,T item)
		{
			db.Item.Insert (index, item);
			EditorUtility.SetDirty (db);
			
		}
		
		public void Remove(T item)
		{
			db.Item.Remove (item);
			EditorUtility.SetDirty (db);
			
		}
		
		public void Remove(int index)
		{
			db.Item.RemoveAt (index);
			EditorUtility.SetDirty (db);
		}
		public void Replace(int index, T i)
		{
			db.Item [index] = i;
			EditorUtility.SetDirty (db);
		}

		void LoadDatabase()
		{
			string dbfullpath = @"Assets/" + dbPath + "/" + dbName;
			
			db= AssetDatabase.LoadAssetAtPath (dbfullpath, typeof(D))as D;
			if (db == null) 
			{
				CreateDatabase(dbfullpath);
			}
			
			
			
			
		}
		void CreateDatabase(string DBF)
		{			{
				if (!AssetDatabase.IsValidFolder ("Assets/"+dbPath)) 
					
					AssetDatabase.CreateFolder("Assets",dbPath);
				
				db = ScriptableObject.CreateInstance<D>()as D;
				AssetDatabase.CreateAsset (db, DBF);
				AssetDatabase.SaveAssets ();
				AssetDatabase.Refresh();
				
			}
	}
		#endif
}
}
