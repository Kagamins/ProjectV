using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
public  partial class ISObjectEditor 
	{
		enum TabState
		{
			WEAPON,
			ARMOR,
			POTION,
			ABOUT,
			QUESTS
		}
		TabState tabstate;
		void TopTabBar()
		{

			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth(true));
			WeaponsTab ();
			ArmorsTab ();
			PotionsTab ();
			QuestsTab ();
			AboutTab ();
			GUILayout.EndHorizontal ();
		}

		void WeaponsTab()
		{
			if (GUILayout.Button ("Weapons"))
				tabstate = TabState.WEAPON;

		}

		void ArmorsTab()
		{
			if (GUILayout.Button ("Armor"))

				tabstate = TabState.ARMOR;
		}


		void PotionsTab()
		{
			if (GUILayout.Button ("Potions"))

				tabstate = TabState.POTION;
		}


		void AboutTab()
		{
			if (GUILayout.Button ("About"))
			tabstate = TabState.ABOUT;
		}
		void QuestsTab ()
		{
			if (GUILayout.Button ("Quests"))
				tabstate = TabState.QUESTS;
		}

    }
}