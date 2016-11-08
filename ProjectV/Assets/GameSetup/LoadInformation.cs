using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LoadInformation  {
	public GameObject Player;
	void start(){
		Player = GameObject.FindWithTag("Player");
	}

	public static void Load(){
		//General Variables Loading 
		GameInformation.Inventory_A_IDs = new List<int> ();
		GameInformation.Inventory_W_IDs = new List<int> ();
		GameInformation.Inventory_P_IDs = new List<int> ();
		GameInformation.InventoryArmors = new List<Armor> ();
		GameInformation.InventoryPotions = new List<Potion> ();
		GameInformation.InventoryWeapons = new List<Weapon> ();
		GameInformation.BodyCount = PlayerPrefs.GetInt ("BodyCount");
		GameInformation.RequiredXP = PlayerPrefs.GetInt ("PlayerRequiredXp");
		GameInformation.CurrentXp = PlayerPrefs.GetInt ("PlayerCurrentXp");
		GameInformation.PlayerLevel = PlayerPrefs.GetInt ("PlayerLevel");
		GameInformation.PlayerName = PlayerPrefs.GetString ("PlayerName");
		GameInformation.Strength = PlayerPrefs.GetInt ("PlayerStrength");
		GameInformation.Vitality = PlayerPrefs.GetInt ("PlayerVitality" );
		GameInformation.Endurance = PlayerPrefs.GetInt ("PlayerEndurance");
		GameInformation.Dexetry = PlayerPrefs.GetInt ("PlayerDextry");
		GameInformation.Intellect= PlayerPrefs.GetInt ("PlayerIntellect");
		GameInformation.PlayerPosX  = PlayerPrefs.GetFloat ("PlayerPosX");
		GameInformation.PlayerPosY	= PlayerPrefs.GetFloat ("PlayerPosY");
		GameInformation.PlayerPosZ	= PlayerPrefs.GetFloat ("PlayerPosZ");
		GameInformation.Currency = PlayerPrefs.GetInt ("PlayerCurrency");
		//Expertise Variables Loading
		GameInformation.Max_Expertise_Points = PlayerPrefs.GetInt ("Max_Expertise_Points");
		GameInformation.Current_Expertise_Points = PlayerPrefs.GetInt ("Current_Expertise_Points");
		GameInformation.Magic_Offense = PlayerPrefs.GetInt ("E_Destruction_Magic_Points" );
		GameInformation.Magic_Support = PlayerPrefs.GetInt("E_Support_Magic_Points");
		GameInformation.Magic_Deffence = PlayerPrefs.GetInt ("E_Defence_Magic_Points");
		GameInformation.Magic_Debuff = PlayerPrefs.GetInt ("E_Debuff_Magic_Points");
		GameInformation.Survival_instinct = PlayerPrefs.GetInt ("E_Survival_Instincts");
		GameInformation.Ranged_Offence = PlayerPrefs.GetInt ("E_Ranged_Offence");
		GameInformation.Ranged_Support = PlayerPrefs.GetInt ("E_Ranged_Support");
		GameInformation.Melee_Offence = PlayerPrefs.GetInt("E_Melee_Offence");
		GameInformation.Melee_Defence = PlayerPrefs.GetInt ("E_Melee_Defence");
		GameInformation.Stat_Points = PlayerPrefs.GetInt ("Stat_Points");
		//inventory variables
		GameInformation.Inv_A_T = PlayerPrefs.GetInt ("Inventory_Armors_Total");
		GameInformation.Inv_W_T = PlayerPrefs.GetInt ("Inventory_Weapons_Total");
		GameInformation.Inv_P_T = PlayerPrefs.GetInt ("Inventory_Potions_Total");
		for(int cnt =0;cnt<GameInformation.Inv_A_T;cnt++){
			GameInformation.Inventory_A_IDs.Add (PlayerPrefs.GetInt("Inv_A_"+cnt));  
		}
		for(int cnt =0;cnt<GameInformation.Inv_W_T;cnt++){
			GameInformation.Inventory_W_IDs.Add (PlayerPrefs.GetInt("Inv_W_"+cnt));  
		}
		for(int cnt =0;cnt<GameInformation.Inv_P_T;cnt++){
			GameInformation.Inventory_P_IDs.Add (PlayerPrefs.GetInt("Inv_P_"+cnt));  
		}

		Debug.Log ("You have Loaded");
		Debug.Log (GameInformation.PlayerName);

	}
}
