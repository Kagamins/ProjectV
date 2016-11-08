using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
public class PPSerialization   {
	public static BinaryFormatter binformater = new BinaryFormatter();
	public static void BSave(string saveTag, object obj)
	{
				MemoryStream memorystream = new MemoryStream ();
				binformater.Serialize (memorystream, obj);
				string temp = System.Convert.ToBase64String (memorystream.ToArray ());
				PlayerPrefs.SetString (saveTag, temp);
	}

		public static object BLoad(string saveTag){
				string temp = PlayerPrefs.GetString (saveTag);
						if (temp == string.Empty) 
						{
							return null;
						}
		MemoryStream memorystream = new MemoryStream (System.Convert.FromBase64String (temp));
		return binformater.Deserialize (memorystream);
	}

//	public static void Load (string Fname)
//	{
//		if (File.Exists (Fname)) 
//		{
//		
//			try{
//				using (Stream str = File.OpenRead(Fname))
//				{
//					BinaryFormatter formater = new BinaryFormatter();
//					return formater.Deserialize(str) as int;
//
//				}
//				
//			}
//			catch (Exception e ){
//				Debug.Log (e.Message);
//			}
//		}
//		return default(T);
//	
//	}
//	public static void save(string Fname, int data) 
//	{
//		using (Stream stream = File.OpenWrite (Fname)) {
//		
//			BinaryFormatter formater = new BinaryFormatter();
//			formater.Serialize (stream, data);
//		}
//	}

	}


