using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using ProjectV.ItemSystem;
using UnityEngine.EventSystems;
[DisallowMultipleComponent]
//[RequireComponent(typeof(PlayerInputsManager))]
[System.Serializable]
public partial class PlayerUIManager : MonoBehaviour
{

	//PlayerSetup Variables
	private Rigidbody Rbody;
 	public Transform RespawnPoint;
	public static Animator _animator;
	private Animator Auraanim;
	public GameObject playerobject;
 	/*
	 Stats Variables
	 */
	public static int Health = 100,maxHealth = 100;
	public static int Mana = 100,MaxMana = 100;
	public static int Stamina = 100 ,MaxStamina = 100;
 
	public static  GUISkin x;
	/********************
	 Inventory variables 
	*/

	public static bool loot_enabled = false;
	public static bool expertise_enabled = false;
	/***
	 * Equiping Variables for Weapons
	 * */
	public static EQType WeaponTypes;
	public static EQSlot Equipment_Slot;
 	public static Texture Crosshair;
	public static  Rect CrosshairRect;
	public static float CrosshairSize = Screen.width*0.1f;
	//HealthBar ManaBar Stamina Bar Variables
 	public static Texture BGBar,StaminaBar,ManaBar,HealthBar,LF;
	public static  Rect SBrRect,MBrRect,HBrRect,BG1,BG2,BG3,LFRect;
	public static float BarSize = Screen.width*0.4f;
	//Camera Manipulation Variables
//	public Camera Player_Cam,MiniMap_Cam;
	public static bool Mount = false;
	/***
	 * Targeting System Variables 
	 * */

	public static bool _Aim= false;
	Ranks _rank;
	public enum Ranks{
		In_Training,
		Soldier,
		Lieutenant,
		Officer,
		Captain,
		Major,
		General
	} 
	void Start ()
	{
		//initialises the health and adjusts it according to the game information 
		Health = 100 +( Health* GameInformation.Vitality/2);
		maxHealth = 100+( maxHealth* GameInformation.Vitality/2);
 		Mana = 100+ ( Mana* GameInformation.Intellect/2);
		MaxMana = 100+ ( MaxMana*GameInformation.Intellect/2);
		Stamina = 100+ ( Stamina* GameInformation.Endurance/2);
		MaxStamina = 100+ (  MaxStamina * GameInformation.Endurance/2);
 		//saves the player object and gets its components 
		playerobject = this.gameObject;
		Rbody = GetComponent<Rigidbody> ();
		_animator = GetComponent<Animator>();
//		Auraanim = HAura.GetComponent<Animator>();
// 		Player_Cam = this.gameObject.GetComponentInChildren<Camera>();
		LF = Resources.Load ("Textures/Sprites/LoadoutBG")as Texture;
 		//Crosshair in the middle of the screen
		Crosshair = Resources.Load ("Textures/Crosshair/Crosshair")as Texture;
		//Stats Bars and their Backgrounds variables 
		HealthBar = Resources.Load ("Textures/Sprites/HBR")as Texture;
		StaminaBar = Resources.Load ("Textures/Sprites/SBR")as Texture;
 		ManaBar = Resources.Load ("Textures/Sprites/MBR")as Texture;
		BGBar = Resources.Load ("Textures/Sprites/BBR")as Texture;
		CrosshairRect = new Rect (Screen.width / 2 - CrosshairSize / 2, Screen.height / 2 - CrosshairSize / 2, CrosshairSize, CrosshairSize);
 		HBrRect = new Rect (Screen.width/5,Screen.height/5,BarSize,BarSize/2);
 		SBrRect = new Rect (0,20,BarSize,BarSize/2);
 		MBrRect = new Rect (0,40,BarSize,BarSize/2);
 		BG1 = new Rect(Screen.width/75,Screen.height/130, BarSize,BarSize/3);
		BG2 = new Rect(Screen.width/75,Screen.height/130+30, BarSize,BarSize/3);
		BG3 = new Rect(Screen.width/75,Screen.height/130+60, BarSize,BarSize/3);
		LFRect = new Rect (Screen.width/2-Screen.width/2,Screen.height/2+Screen.height/4,Screen.width/6,Screen.height/5);
	
//		AddAllEnemies ();

 	}


	public static void statIncrease()
	{
		maxHealth  = 100+( maxHealth* GameInformation.Vitality);
		MaxMana  = 100+( MaxMana *GameInformation.Intellect);
		MaxStamina  =100+(  MaxStamina * GameInformation.Endurance);
 		Health = maxHealth;
		Mana  =  MaxMana ;
		Stamina  = MaxStamina;

	}


	void Update ()
	{
		
		if (Health < 1) {
			Respawn ();
		}
//	
		//Weapon Equiping Updates
 		if (AlphaMenu.NewGame) {
			Equiped_Weapon = weapon1;
			weapon1 = GameInformation.InventoryWeapons [0];
			weapon2 = GameInformation.InventoryWeapons [1];
			weapon3 = GameInformation.InventoryWeapons [2];
			AlphaMenu.NewGame = false;
			WeaponTypes = EQType.None;

		}
		if (AlphaMenu.HaveLoaded) {
			Equiped_Weapon = weapon1;
			weapon1 = GameInformation.InventoryWeapons [0];
			weapon2 = GameInformation.InventoryWeapons [1];
			weapon3 = GameInformation.InventoryWeapons [2];
			AlphaMenu.HaveLoaded = false;
			WeaponTypes = EQType.None;
		}
 
		//Expertise Functions
		if (GameInformation.PlayerLevel == 1) {
			GameInformation.Max_Expertise_Points = 1000;
			_rank = Ranks.In_Training;
			PauseMenu._Rank = _rank.ToString();
		}
		if (GameInformation.PlayerLevel == 10) {
			GameInformation.Max_Expertise_Points = 2500;
			_rank = Ranks.Soldier;
			PauseMenu._Rank = _rank.ToString();


		}
		if (GameInformation.PlayerLevel == 20) 
		{
			GameInformation.Max_Expertise_Points = 3500;
			_rank = Ranks.Lieutenant;
			PauseMenu._Rank = _rank.ToString();
 


		}
		if (GameInformation.PlayerLevel == 30) 
		{
			GameInformation.Max_Expertise_Points = 5500;
			_rank = Ranks.Officer;
			PauseMenu._Rank = _rank.ToString();


		}
		if (GameInformation.PlayerLevel == 40) 
		{
			GameInformation.Max_Expertise_Points = 9000;
			_rank = Ranks.Captain;		
			PauseMenu._Rank = _rank.ToString();



		}
		if (GameInformation.PlayerLevel == 50) 
		{
			GameInformation.Max_Expertise_Points = 19000;
			_rank = Ranks.Major;
			PauseMenu._Rank = _rank.ToString();
 		}
		//Adjusts stats whenever the character levels up or equips items 
//		AdjustStats ();
		ScaleAdjustment ();
		 

	


		if (AlphaMenu.HaveLoaded) 
		{
			LoadLocation();
			StatAdjustment ();
			AlphaMenu.HaveLoaded = false;
		}
		StoreLocation ();

		if (Health<=0 )
		{
			
			Respawn ();
				}

		 

	}


	void ManaGeneration(){
		Mana += Mana * Random.Range( 1, 25);
		CancelInvoke ();
	}


	public void StaminaGeneration(){
		Stamina += Stamina * Random.Range( 1, 25);
		CancelInvoke ();
	}


	void HealthGeneration(){
		Health += Health * Random.Range( 1, 25);
		CancelInvoke ();
	}


//	void FillAmount(){
////		HealthBar.fillAmount = (float)Health / (float)maxHealth;
////		StaminaBar.fillAmount = (float)Stamina / (float)MaxStamina;
////		ManaBar.fillAmount = (float)Mana / (float)MaxMana;
//	}


	public void PHit(int damage){
		Health -= damage;
	}


	void Respawn(){
		playerobject.transform.position = new Vector3 (RespawnPoint.position.x, RespawnPoint.position.y, RespawnPoint.position.z);
		Health = maxHealth;
		Mana = MaxMana;
		Stamina = MaxStamina;

	}


	void StoreLocation()
	{

		GameInformation.PlayerPosX = transform.position.x;
		GameInformation.PlayerPosY = transform.position.y + 3f;
		GameInformation.PlayerPosZ = transform.position.z;
	}

	public void Moveset(string x){
		
		bool z = true;


	}
	void LoadLocation()
	{
		

		transform.position = new Vector3 (GameInformation.PlayerPosX, GameInformation.PlayerPosY, GameInformation.PlayerPosZ);
	}


	public void OnGUI()
	{
		int Loot_window_id = 1;
		Rect Loot_window_rect = new Rect (Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 4);
		GUI.skin = x;
		if (_Aim) {
			GUI.DrawTexture (CrosshairRect, Crosshair);
		}
//		GUI.DrawTexture (LFRect,LF);
		GUI.Label (new Rect(LFRect.x,LFRect.y,LFRect.width+BarSize/12,40),GameInformation.PlayerName+" : "+_rank.ToString(),"Box");
 		//GUI of the Healthbars
		GUI.DrawTexture (BG1,BGBar);
		GUI.DrawTexture (BG2,BGBar);
		GUI.DrawTexture (BG3,BGBar);
 		GUI.DrawTexture (HBrRect,HealthBar);
		GUI.DrawTexture (SBrRect,StaminaBar);
		GUI.DrawTexture (MBrRect,ManaBar);
		GUI.Box (new Rect(0,Screen.height-Screen.height/13+BarSize/15,Screen.width ,BarSize/6),GameInformation.CurrentXp.ToString()+"/"+GameInformation.RequiredXP.ToString());
		GUI.Box (new Rect(0,Screen.height-Screen.height/13+BarSize/15,Screen.width*(GameInformation.CurrentXp/(float)GameInformation.RequiredXP),BarSize/6)," ");
		GUI.Label (HBrRect,"Health : "+Health+"/"+maxHealth);
		GUI.Label (SBrRect,"Stamina : "+Stamina+"/"+MaxStamina);
		GUI.Label (MBrRect,"Mana : "+Mana+"/"+MaxMana);
//
		if(PlayerInputsManager._target!=null){
			GUI.Label (new Rect(Screen.width/2,Screen.height/2,Screen.width/8*(PlayerInputsManager._target.GetComponentInParent<Enemy>().health/(float)PlayerInputsManager._target.GetComponentInParent<Enemy>().maxhealth),50),PlayerInputsManager._target.GetComponentInParent<Enemy>().health.ToString()+"/"+PlayerInputsManager._target.GetComponentInParent<Enemy>().maxhealth.ToString(),"Box");	
		}

		if (Health < maxHealth / 2) {
			
		 
			if (GUI.Button (new Rect (0, Screen.height / 2 + Screen.height / 3, 80, 40), "BailOut")) {
				CameraManipulation.x = true;
			}
		}
			if (Mount) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2-50,300,40),"Mount the Vehicle","Box");
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 40, 40), "Yes")) {
				CameraManipulation.x = true;
				this.gameObject.SetActive (false);
			} 

		}
		 if (loot_enabled) {
			Loot_window_rect = GUI.Window (Loot_window_id, Loot_window_rect, Loot, "Loot Window ");
		}
	}
	public static void StatAdjustment()
	{
//		Health =   Health + Health* GameInformation.Vitality;
		maxHealth =  Health+ 2* GameInformation.Vitality;
//		Mana =   Mana +Mana* GameInformation.Intellect;
		MaxMana = Mana +2 *GameInformation.Intellect;
//		Stamina =  Stamina + Stamina* GameInformation.Endurance;
		MaxStamina = Stamina+ 2 * GameInformation.Endurance;
 	}

	public static void DuringBattle_StatAdjustment()
	{
 		maxHealth =Health* GameInformation.Vitality;
 		MaxMana =MaxMana *GameInformation.Intellect;
 		MaxStamina =Stamina * GameInformation.Endurance;
	}

 
	public static void Loot(int id )
	{
		bool wep=false;
		int y = 6;
//		for (int cnt = 0; cnt < x; cnt++) {
//			GUILayout.BeginHorizontal ();
		if (!wep) {
			if (GUILayout.Button (PauseMenu.WDB.Get (TreasureChest.W_ItemID).Name)) {
				ISWeapon isw = PauseMenu.WDB.Get (TreasureChest.W_ItemID);
				Weapon Wep = new Weapon ();
				Wep.Name = isw.Name;
				Wep.ItemID = TreasureChest.W_ItemID;
				Wep.Burden = isw.ISBurden;
				Wep.Equipment_Slot = isw.EquipmentSlot;
				Wep.Min_Damage = isw.MinDamage;
				Wep.Durability = isw.Durability;
				Wep.Max_Durability = isw.MaxDurability;
				Wep.Value = isw.ISValue;
				Wep.Equipment_Element = isw.EQElement;
				Wep.Equipment_Type = isw.EquipmentType;
				Wep.Equipment_Range = isw.EquipmentRange;
				GameInformation.InventoryWeapons.Add (Wep);
				wep = true;
			}
		}
		GUILayout.Button (PauseMenu.ADB.Get(TreasureChest.A_ItemID).Name);
		GUILayout.Button (PauseMenu.PDB.Get(TreasureChest.P_ItemID).Name);

//			}GUILayout.EndHorizontal ();}

		if (GUILayout.Button ("X")) {
			loot_enabled = false;
			wep = false;
		}
		GUI.DragWindow ();
	}
	 
	public static void ScaleAdjustment(){
		CrosshairRect = new Rect (Screen.width / 2 - CrosshairSize / 2, Screen.height / 2 - CrosshairSize / 2, CrosshairSize, CrosshairSize);
		HBrRect = new Rect(Screen.width/75,Screen.height/100, BarSize* (Health/(float)maxHealth),BarSize/13);
		MBrRect = new Rect(Screen.width/75,Screen.height/110+BarSize/13, BarSize* (Mana/(float)MaxMana),BarSize/13);
		SBrRect = new Rect(Screen.width/75,Screen.height/120+BarSize/13*2, BarSize* (Stamina/(float)MaxStamina),BarSize/13);
		BG1 = new Rect(Screen.width/75,Screen.height/100, BarSize,BarSize/13);
		BG2 = new Rect(Screen.width/75,Screen.height/110+BarSize/13, BarSize,BarSize/13);
		BG3 = new Rect(Screen.width/75,Screen.height/120+BarSize/13*2, BarSize,BarSize/13);
		LFRect = new Rect (Screen.width/2-Screen.width/2,Screen.height/2+Screen.height/4,Screen.width/6,Screen.height/5);
	}
}