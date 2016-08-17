using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{

public partial class  ISObjectCategory  {
		protected ISArmorDatabase db{ get; set;}
		protected string dbName { get; set;}//= name ofDataBase.asset";
//		protected string dbPath{ get; set;} //path to "Database";
		const string dbPath = @"Database";


		public ISObjectCategory()
		{
			dbName = @"PVArmorDataBase.asset";

		}
		public string DBFullPath 
		{
			get {return @"Assets/"+dbPath+"/"+ dbName;}

		}

		public void OnEnable()
		{
			if (db == null)
			{
				db = ISArmorDatabase.GetDatabase<ISArmorDatabase> (dbPath, dbName);
			}

		}
		public void OnGUI(Vector2 BtnSize)
		{
			ListView (BtnSize);
			ItemDetails();
		}



}
}