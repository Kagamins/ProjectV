using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveInformation  {

		
	public static void Save(){
//General Game Variables
		PlayerPrefs.SetInt("Stat_Points",GameInformation.Stat_Points);
		PlayerPrefs.SetInt ("PlayerLevel", GameInformation.PlayerLevel);
		PlayerPrefs.SetString ("PlayerName", GameInformation.PlayerName);
		PlayerPrefs.SetInt ("PlayerStrength", GameInformation.Strength);
		PlayerPrefs.SetInt ("PlayerVitality", GameInformation.Vitality);
		PlayerPrefs.SetInt ("PlayerEndurance", GameInformation.Endurance);
		PlayerPrefs.SetInt ("PlayerDextry", GameInformation.Dexetry);
		PlayerPrefs.SetInt ("PlayerIntellect", GameInformation.Intellect);
		PlayerPrefs.SetInt ("BodyCount",GameInformation.BodyCount);
		PlayerPrefs.SetFloat ("PlayerPosX",GameInformation.PlayerPosX);
		PlayerPrefs.SetFloat ("PlayerPosY",GameInformation.PlayerPosY);
		PlayerPrefs.SetFloat ("PlayerPosZ",GameInformation.PlayerPosZ);
		PlayerPrefs.SetInt ("PlayerCurrentXp", GameInformation.CurrentXp);
		PlayerPrefs.SetInt ("PlayerRequiredXp",GameInformation.RequiredXP);
		PlayerPrefs.SetInt ("PlayerCurrency",GameInformation.Currency);
//Expertise Variables
		PlayerPrefs.SetInt("Max_Expertise_Points",GameInformation.Max_Expertise_Points);
		PlayerPrefs.SetInt ("Current_Expertise_Points", GameInformation.Current_Expertise_Points);
		PlayerPrefs.SetInt ("E_Destruction_Magic_Points", GameInformation.Magic_Offense);
		PlayerPrefs.SetInt("E_Support_Magic_Points",GameInformation.Magic_Support);
		PlayerPrefs.SetInt ("E_Defence_Magic_Points", GameInformation.Magic_Deffence);
		PlayerPrefs.SetInt ("E_Debuff_Magic_Points",GameInformation.Magic_Debuff);
		PlayerPrefs.SetInt ("E_Survival_Instincts",GameInformation.Survival_instinct);
		PlayerPrefs.SetInt ("E_Ranged_Offence",GameInformation.Ranged_Offence);
		PlayerPrefs.SetInt ("E_Ranged_Support",GameInformation.Ranged_Support);
		PlayerPrefs.SetInt("E_Melee_Offence",GameInformation.Melee_Offence);
		PlayerPrefs.SetInt ("E_Melee_Defence",GameInformation.Melee_Defence);
		PlayerPrefs.SetInt ("Inventory_Armors_Total", GameInformation.InventoryArmors.Count);
		PlayerPrefs.SetInt ("Inventory_Weapons_Total", GameInformation.InventoryWeapons.Count);
		PlayerPrefs.SetInt ("Inventory_Potions_Total", GameInformation.InventoryPotions.Count);

		for (int cnt = 0;cnt<GameInformation.InventoryArmors.Count;cnt++){
			PlayerPrefs.SetInt("Inv_A_"+cnt,GameInformation.InventoryArmors [cnt].ItemID);
					}
		for (int cnt = 0;cnt<GameInformation.InventoryWeapons.Count;cnt++){
			PlayerPrefs.SetInt("Inv_W_"+cnt,GameInformation.InventoryWeapons [cnt].ItemID);
		}
		for (int cnt = 0;cnt<GameInformation.InventoryPotions.Count;cnt++){
			PlayerPrefs.SetInt("Inv_P_"+cnt,GameInformation.InventoryPotions [cnt].Item_ID);
		}

		Debug.Log ("You have Saved");
	}
	}
