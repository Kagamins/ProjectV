
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq; //needed for ElementAt


namespace ProjectV.ItemSystem
{
public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality> {
		public int GetIndex(string name)
		{
			return  item.FindIndex (a => a.Name == name);
		}
	}
}