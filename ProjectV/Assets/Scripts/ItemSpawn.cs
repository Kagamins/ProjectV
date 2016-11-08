////Spawn Item from Db
////Connect to Db inGame
//using UnityEngine;
//using System.Collections;
//using  ProjectV.ItemSystem;
//
//
//[DisallowMultipleComponent]
//public class ItemSpawn : MonoBehaviour {
//	public static ISQuestDatabase QDB;
//	public static  ISWeaponDatabase WDB;
//	public static ISArmorDatabase ADB;
//	public  static bool SpawnButton = false;
//	public static Transform SpawnPoint;
//
//	public virtual void OnGUI()
//	{
//		if (SpawnButton) {
//		for (int cnt = 0; cnt < ADB.Count; cnt++) {
//			if (GUILayout.Button ("Spawn : " + ADB.Get (cnt).Name)) {
//				SpawnA (cnt);
//			}
//		}
//		for (int cnt = 0; cnt < WDB.Count; cnt++) {
//			if (GUILayout.Button ("Spawn : " + WDB.Get (cnt).Name)) {
//				SpawnW (cnt);
//			}
//		}
//
////		for (int cnt = 0; cnt < QDB.Count; cnt++) {
////			GUILayout.BeginVertical ("Window");
////			GUILayout.Button (QDB.Get (cnt).Name);
////			GUILayout.Label (QDB.Get (cnt).QuestDialog);
////			GUILayout.Label ("Required Level" + QDB.Get (cnt).ISBurden.ToString ());
////			GUILayout.Label ("Reward" + QDB.Get (cnt).ISValue.ToString ());
////			GUILayout.BeginHorizontal ();
////			GUILayout.Button ("Accept");
////			GUILayout.Button ("Decline");
////			GUI.DragWindow ();
////			GUILayout.EndVertical ();
//		}
//	
//
//	}
//
//	public static void SpawnW(int index)
//	{
//		ISWeapon isw = WDB.Get (index);
//		GameObject weapon = Instantiate (isw.Prefab);
//		weapon.name = isw.Name;
//		Weapon myweapon = weapon.AddComponent<Weapon> ();
//		myweapon.ItemID = index;
//		myweapon.Burden = isw.ISBurden;
//		myweapon.Equipment_Slot = isw.EquipmentSlot;
//		myweapon.Min_Damage = isw.MinDamage;
//		myweapon.Durability = isw.Durability;
//		myweapon.Max_Durability = isw.MaxDurability;
//		myweapon.Value = isw.ISValue;
//		myweapon.tag = "Weapon";
//		myweapon.Equipment_Element = isw.EQElement;
//		myweapon.Equipment_Type = isw.EquipmentType;
//		myweapon.Equipment_Range = isw.EquipmentRange;
//		PlayerUIManager.Inventory_Weapons.Add (myweapon);
//		Instantiate (isw.Prefab,SpawnPoint.position,SpawnPoint.rotation);
//	}
//	public static void SpawnA(int index)
//	{
//		ISArmor isw = ADB.Get (index);
//		GameObject armor = Instantiate (isw.Prefab);
//		armor.name = isw.Name;
//		Armor myArmor = armor.AddComponent<Armor> ();
//		myArmor.ItemID = index;
//		myArmor.Burden = isw.ISBurden;
//		myArmor.Equipment_Slot = isw.EquipmentSlot;
//		myArmor.Min_Armor_Rate = (int)isw.Armor.x;
//		myArmor.Max_Armor_Rate = (int)isw.Armor.y;
//		myArmor.Durability = isw.Durability;
//		myArmor.Max_Durability = isw.MaxDurability;
//		myArmor.Value = isw.ISValue;
//		myArmor.tag = "Armor";
//		
//	}
////
//////	void Update(){
//////		if (Input.GetMouseButtonDown (0)) {
//////			Ray ray = GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);
//////			RaycastHit  hit;
//////			if (Physics.Raycast (ray, out hit)) {
//////				GameObject other = new GameObject();
//////				if (other.gameObject.tag == "Enemy") {
//////					Destroy (other);
//////				}
//////			}
//////		}
//////	}
////
////
//}