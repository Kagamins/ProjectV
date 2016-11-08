using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{

	public partial class  ISObjectCategory  {
		int _listviewwidth = 200;
//		int _listviewbuttonwidth = 190;
//		int _listviewbuttonheight = 25;
		int _selectedindex = -1;
		ISArmor temparmor;
		bool CreateNewArmor = false;
		bool show_details = false;
		Vector2 Scroll = Vector2.zero;
		public void ListView(Vector2 BSize)
		{
			Scroll = GUILayout.BeginScrollView (Scroll,"Box", GUILayout.ExpandHeight (true),GUILayout.Width(_listviewwidth));
			for (int cnt = 0; cnt<db.Count; cnt++) {
				if(GUILayout.Button(db.Get (cnt).Name,GUILayout.Width (BSize.x),GUILayout.Height (BSize.y)))
				{
					
					_selectedindex = cnt;
					temparmor = new ISArmor(db.Get(cnt));
					//					tempweapon = new ISWeapon();
					//					tempweapon.Clone(db.Get(cnt));
					
					temparmor = db.Get (cnt);
					show_details = true;
					CreateNewArmor = true;
//					state = DisplayState.DETAILS;
				}
				
			} GUILayout.EndScrollView ();

		}

}
}