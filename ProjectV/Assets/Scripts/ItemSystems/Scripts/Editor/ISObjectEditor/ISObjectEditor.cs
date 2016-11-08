using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace ProjectV.ItemSystem{
public  partial class ISObjectEditor : EditorWindow 
	{
	
//		ISWeaponDatabase wdb;
//		ISObjectCategory adb = new ISObjectCategory();
		ISObjectDatabaseType<ISQuestDatabase,ISQuest> questdb = new ISObjectDatabaseType<ISQuestDatabase,ISQuest> (@"QuestDB");

		ISObjectDatabaseType<ISWeaponDatabase,ISWeapon> weapondb = new ISObjectDatabaseType<ISWeaponDatabase,ISWeapon> (@"WeaponDB");
		ISObjectDatabaseType<ISArmorDatabase,ISArmor> armordb = new ISObjectDatabaseType<ISArmorDatabase,ISArmor> (@"ArmorDB");
		ISObjectDatabaseType<ISPotionDatabase,ISPotion> potiondb = new ISObjectDatabaseType<ISPotionDatabase, ISPotion>(@"PotionDB");

		Vector2 BtnSize = new  Vector2(190,25);
//		Vector2 _scrollpos = Vector2.zero;
	[MenuItem("PV/Database/Object Editor %#i")]
	public static void init(){
		ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor> ();
		window.minSize = new Vector2 (800, 600);
		window.titleContent.text="Item Database";
		window.Show ();
	}
	
		void OnEnable()
	{

				weapondb.OnEnable("Weapon");
				armordb.OnEnable("Armor");
				potiondb.OnEnable ("Potion");
				questdb.OnEnable ("Quest");
				tabstate = TabState.ABOUT;
	}

	void OnGUI(){
			TopTabBar ();
			GUILayout.BeginHorizontal ();
			switch (tabstate){
			case TabState.WEAPON:
				weapondb.OnGUI(BtnSize);
				break;
			case TabState.ARMOR:
				armordb.OnGUI(BtnSize);
				break;
			case TabState.POTION:
				potiondb.OnGUI(BtnSize);
				break;
			case TabState.QUESTS:
				questdb.OnGUI(BtnSize);
				break;
			default:
				GUILayout.Label ("About");
				break;
			}
			GUILayout.EndHorizontal ();
			BottomBar ();


	}
}
}
