using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
	
public  class GameInformation : MonoBehaviour {
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
		Max_Expertise_Points = 1000;
		InventoryArmors = new List<Armor> ();
		InventoryPotions = new List<Potion>();
		InventoryWeapons = new List<Weapon> ();
	}


	//Expertise Variables
	public static int Max_Expertise_Points{ get; set;}
	public static int Current_Expertise_Points{ get; set;}
	//Expertise Contributions
	public static int Magic_Offense{ get; set;}
	public static int Magic_Support{ get; set;}
	public static int Magic_Deffence{ get; set;}
	public static int Magic_Debuff{ get; set;}
	public static int Melee_Offence{ get; set;}
	public static int Melee_Defence{ get; set;}
	public static int Survival_instinct{ get; set;}
	public static int Ranged_Offence{ get; set;}
	public static int Ranged_Support{ get; set;}
	//Ingame Variables
	public static int Currency{get; set;}
	public static int Stat_Points{get; set;}
	public static int BodyCount{ get; set;}
	public static string PlayerName{ get; set;}
	public static int PlayerLevel{ get; set;}
	public static int Endurance{get;set;}
	public static int Intellect{get;set;}
	public static int Dexetry{get;set;}
	public static int Vitality{get;set;}
	public static int Strength{get;set;}
	public static int Aim{ get; set;}
	public static int CurrentXp{ get; set;}
	public static int RequiredXP{ get; set;}
	public static float PlayerPosX { get; set;}
	public static float PlayerPosY { get; set;}
	public static float PlayerPosZ { get; set;}
	//Inventory Variables
	public static List<Armor> InventoryArmors{get; set;}
	public static List<Weapon> InventoryWeapons = new List<Weapon>();
	public static List<Potion> InventoryPotions { get; set;}
	public static List<int>Inventory_A_IDs { get; set;}
	public static List<int>Inventory_W_IDs { get; set;}
	public static List<int>Inventory_P_IDs { get; set;}
	public static int Inv_A_T{ get; set;}
	public static int Inv_W_T{ get; set;}
	public static int Inv_P_T{ get; set;}

}
