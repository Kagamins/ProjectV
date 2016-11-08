using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using ProjectV.ItemSystem;
public partial class PlayerUIManager : MonoBehaviour {

 
	public static Weapon weapon1,weapon2,weapon3,Equiped_Weapon;
	public static Armor armors;
//	bool Equip = false;
	[SerializeField]public  List<Potion> Inventory_Potions = new List<Potion>();






	void EquipItem()
	{




		}


	void OnCollisionEnter(Collision other)
	{   
		
	}
	void AddItemArmor(Armor addedarmor)
	{
 		GameInformation.InventoryArmors.Add(addedarmor);
 	}
	void AddItemWeapon(Weapon addedweapon)
	{
		GameInformation.InventoryWeapons.Add (addedweapon);
	}

	void RemoveAItem(int index)
	{
		Inventory_Armors.RemoveAt (index);
	}
	void RemoveWItem(int index)
	{
		Inventory_Weapons.RemoveAt (index);
	}

}
