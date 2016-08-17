#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectV.ItemSystem{

	public class ScriptableObjectDatabase <T>: ScriptableObject where T:class
	{
		[SerializeField] protected List<T> item = new List<T> ();
		public List <T> Item
		{
			get{return item;}
		}
#if UNITY_EDITOR
		public void Add(T i)
		{
			item.Add (i);
			EditorUtility.SetDirty (this);
		}

		public void Insert(int index,T i)
		{
			item.Insert (index, i);
			EditorUtility.SetDirty (this);
			
		}

		public void Remove(T i)
		{
			item.Remove (i);
			EditorUtility.SetDirty (this);
			
		}

		public void Remove(int index)
		{
			item.RemoveAt (index);
			EditorUtility.SetDirty (this);
		}
#endif
		public int Count{get{return item.Count;}}

		public T Get(int index)
		{
			return item.ElementAt (index);
		}
#if UNITY_EDITOR
		public void Replace(int index, T i)
		{
			item [index] = i;
			EditorUtility.SetDirty (this);
		}

		public static U GetDatabase<U>(string dbpath, string dbname)where U :ScriptableObject
		{
			string dbfullpath = @"Assets/" + dbpath + "/" + dbname;

			U db= AssetDatabase.LoadAssetAtPath (dbfullpath, typeof(U))as U;
				if (db == null)
			{
					if (!AssetDatabase.IsValidFolder ("Assets/"+dbpath)) 
						
						AssetDatabase.CreateFolder("Assets",dbpath);
					
					db = ScriptableObject.CreateInstance<U>()as U;
					AssetDatabase.CreateAsset (db, dbfullpath);
					AssetDatabase.SaveAssets ();
					AssetDatabase.Refresh();
					
				}
			return db;
				

		}
#endif
}
}
