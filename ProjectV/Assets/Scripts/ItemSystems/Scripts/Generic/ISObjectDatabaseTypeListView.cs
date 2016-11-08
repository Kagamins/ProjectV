using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{

	public partial class ISObjectDatabaseType<D,T> where D:ScriptableObjectDatabase<T> where T:ISObject,new() {
		int _listviewwidth = 200;
//		int _listviewbuttonwidth = 190;
//		int _listviewbuttonheight = 25;
		int _selectedindex = -1;
		T tempItem;
		bool CreateNewItem = false;
		bool show_details = false;
		Vector2 Scroll = Vector2.zero;
		public void ListView(Vector2 BSize)
		{
			Scroll = GUILayout.BeginScrollView (Scroll,"Box", GUILayout.ExpandHeight (true),GUILayout.Width(_listviewwidth));
			for (int cnt = 0; cnt<db.Count; cnt++) {
				if(GUILayout.Button(db.Get (cnt).Name,GUILayout.Width (BSize.x),GUILayout.Height (BSize.y)))
				{
					
					_selectedindex = cnt;
					tempItem = new T();
					tempItem.Clone(db.Get(cnt));
					tempItem = db.Get (cnt);
					show_details = true;
					CreateNewItem = true;
//					staCreateNewArmorate.DETAILS;
				}
				
			} GUILayout.EndScrollView ();

		}

}
}