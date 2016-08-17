using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ProjectV.ItemSystem;
 
	public  class PauseMenu : MonoBehaviour {

	public static bool GUIEnabled = false;
	public GUISkin PlayerUI;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public static Rect WindowPlaceHolder = new  Rect (10,300,350,450);
	public static Rect WindowAvatarArea = new Rect (50,350,600,Screen.height/3);
	public static int WindowID = 0;
	public static int inv_t = 0;
	public static ISArmorDatabase ADB;
	public static ISWeaponDatabase WDB;
	public static ISPotionDatabase PDB;
	public static int I_P_ID;
	public static int I_A_ID;
	public static int I_W_ID;
	public static bool A = false;



	// Use this for initialization
	
		public enum inventory_tabs{
			Weapons,
			Potions,
			Armors
		}
		inventory_tabs  inv_T;
	public void Start(){
			//Upon Game Start Initilaizes the Databases
			PDB = Resources.Load ("PotionDB")as ISPotionDatabase;

			WDB = Resources.Load ("WeaponDB")as ISWeaponDatabase;

			ADB = Resources.Load ("ArmorDB")as ISArmorDatabase;

//			if (!AlphaMenu.NewGame & !AlphaMenu.HaveLoaded) {
//			GameInformation.Max_Expertise_Points = 1000;
//			GameInformation.InventoryArmors = new List<Armor> ();
//			GameInformation.InventoryWeapons = new List<Weapon> ();
//		    GameInformation.InventoryPotions = new List<Potion> ();
//			GameInformation.Inv_A_T = 0;
//			GameInformation.Stat_Points = 100;
//			GameInformation.RequiredXP = 100;
//			GameInformation.PlayerLevel = 1;
//			GameInformation.PlayerName = "Tester Kyun";
//			for (int cnt = 0; cnt < 3; cnt++) {
//				ISWeapon isw = WDB.Get (cnt);
//				Weapon myweapon = new Weapon ();
//				myweapon.ItemID = cnt;
//				myweapon.Name = isw.Name;
//				myweapon.Burden = isw.ISBurden;
//				myweapon.Equipment_Slot = isw.EquipmentSlot;
//				myweapon.Min_Damage = isw.MinDamage;
//				myweapon.Durability = isw.Durability;
//				myweapon.Max_Durability = isw.MaxDurability;
//				myweapon.Value = isw.ISValue;
//				myweapon.Equipment_Element = isw.EQElement;
//				myweapon.Equipment_Type = isw.EquipmentType;
//				myweapon.Equipment_Range = isw.EquipmentRange;
//				GameInformation.InventoryWeapons.Add (myweapon);
//			}
//		}

	}
	// Update is called once per frame
	void Update () {
 
 
		if (Input.GetButtonDown ("Pause_Toggle")) {
			if (!CameraManipulation.x) {
				CameraManipulation.z = false;
				CameraManipulation.pause = false;
			}if (CameraManipulation.x) {
				CameraManipulation.z = true;
 			}
		}
 
	
 			if (AlphaMenu.HaveLoaded) {
			for(int cnt =1;cnt<GameInformation.Inv_A_T;cnt++)
			{
				ISArmor isa = ADB.Get (GameInformation.Inventory_A_IDs[cnt]);
				Armor myArmor = new Armor();
				myArmor.Name = isa.Name;
				myArmor.ItemID = I_A_ID;
				myArmor.Burden = isa.ISBurden;
				myArmor.Equipment_Slot = isa.EquipmentSlot;
				myArmor.Min_Armor_Rate = (int)isa.Armor.x;
				myArmor.Max_Armor_Rate = (int)isa.Armor.y;
				myArmor.Durability = isa.Durability;
				myArmor.Max_Durability = isa.MaxDurability;
				myArmor.Value = isa.ISValue;
				GameInformation.InventoryArmors.Add (myArmor);
				inv_t++;
			}
			for(int cnt =1;cnt<GameInformation.Inv_W_T;cnt++)
			{
				ISWeapon isw = WDB.Get (GameInformation.Inventory_W_IDs[cnt]);
				Weapon myWeapon = new Weapon();
				myWeapon.ItemID = I_W_ID;
				myWeapon.Name = isw.Name;
				myWeapon.Burden = isw.ISBurden;
				myWeapon.Equipment_Slot = isw.EquipmentSlot;
				myWeapon.Min_Damage = isw.MinDamage;
				myWeapon.Durability = isw.Durability;
				myWeapon.Max_Durability = isw.MaxDurability;
				myWeapon.Value = isw.ISValue;
				myWeapon.Equipment_Element = isw.EQElement;
				myWeapon.Equipment_Type = isw.EquipmentType;
				myWeapon.Equipment_Range = isw.EquipmentRange;
				GameInformation.InventoryWeapons.Add (myWeapon);
				inv_t++;
			}
			for(int cnt =1;cnt<GameInformation.Inv_P_T;cnt++)
			{
				ISPotion isp = PDB.Get (GameInformation.Inventory_P_IDs[cnt]);
				Potion myPotion = new Potion ();
				myPotion.Item_ID = I_P_ID;
				myPotion.Value = isp.ISValue;
				myPotion.Cool_Down = isp.CoolDownTime;
				myPotion.Max_Stack = isp.MaxStack;
				myPotion.Name = isp.Name;
				GameInformation.InventoryPotions.Add (myPotion);
				inv_t++;
			}
			AlphaMenu.HaveLoaded = false;
			}
}
			

	 
	void OnGUI(){
//			GUI.skin = PlayerUI;
//		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50),"Body Count : " + GameInformation.BodyCount.ToString());
 
				
				// Variables
				bool IsDestruction_Magic = false;
				bool IsDebuff_Magic = false;
				bool IsSupport_Magic = false;
				bool IsDefensive_Magic = false;
				bool IsMelee_Offence = false;
				bool IsMelee_Defence = false;
				bool IsSurvival_Instincts = false;
				bool IsRanged_Offence = false;
				bool IsRanged_Support = false;
				bool IsExpertiseMenu = true;
				//		//GuiFunctions inside the Expertise Menu
				GUILayout.BeginHorizontal ("Box");
				GUILayout.BeginVertical( );

			GUILayout.Label ("Max Expertise Points : " + GameInformation.Max_Expertise_Points.ToString());


					//Magic
				GUILayout.BeginHorizontal();
					GUILayout.Label ("Destructive Magic : " + GameInformation.Magic_Offense.ToString ());
					if (GUILayout.Button ("+")) {
						if (!IsDestruction_Magic) {
							IsDestruction_Magic = true;
						}
					}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal();

				GUILayout.Label ("Debuff Magic : " + GameInformation.Magic_Debuff.ToString ());

					if (GUILayout.Button ("+")) {
						if (!IsDebuff_Magic) {
							IsDebuff_Magic = true;
						}
					}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal();
				GUILayout.Label ("Defensive Magic : " + GameInformation.Magic_Deffence.ToString ());
					if (GUILayout.Button ("+")) {
						if (!IsDefensive_Magic) {
							IsDefensive_Magic = true;
						}
					}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal();
				GUILayout.Label ("Support Magic : " + GameInformation.Magic_Support.ToString());

					if (GUILayout.Button ("+")) {
						if (!IsSupport_Magic) {
							IsSupport_Magic = true;
						}
					}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal();


					//Melee

				GUILayout.Label ("Melee Tacttics : " + GameInformation.Melee_Offence.ToString ());
					if (GUILayout.Button ("+")) {
					if (!IsMelee_Offence) {
						IsMelee_Offence = true;
					} else {
						IsMelee_Offence = false;
					}
					}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal();
				GUILayout.Label ("Defensive Techniques : " + GameInformation.Melee_Defence.ToString ());
					if (GUILayout.Button ("+")) {
						if (!IsMelee_Defence) {
							IsMelee_Defence = true;
						}
					}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal();
					//Ranged
				GUILayout.Label ("Ranged Techniques : " + GameInformation.Ranged_Offence.ToString ());
				
					if (GUILayout.Button ("+")) {
						if (!IsRanged_Offence) {
							IsRanged_Offence = true;
					}
					}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal();
				GUILayout.Label ("Ranged Support : " + GameInformation.Ranged_Support.ToString ());
					if (GUILayout.Button ("+")) {
						if (!IsRanged_Support) {
							IsRanged_Support = true;
						}
					}
				GUILayout.EndHorizontal ();
				GUILayout.EndVertical ();

				if (IsMelee_Offence)
				{
					
					GUILayout.BeginHorizontal ( );
					GUILayout.Label ("1st Strike ");
				if (GameInformation.Melee_Offence == 200) {
						GUILayout.Button ("/");
					} else {
						GUILayout.Button ("X");
					}
					GUILayout.EndHorizontal ();


				}
				GUILayout.EndHorizontal ();
			


				if(GUI.Button(new Rect(225,175,Screen.width / 8, 20),"IncreaseLevel"))
					{
					AddExperience.AddExp ();
					}

				if(GUI.Button(new Rect(225,205,Screen.width / 8, 20),"Additem A"))
				{
					
					I_A_ID = Random.Range (0, ADB.Count);
					ISArmor isa = ADB.Get (I_A_ID);
					GameObject A = new GameObject ();
					A.name = isa.Name;
					Armor myArmor = A.AddComponent<Armor>();
					myArmor.Name = isa.Name;
					myArmor.ItemID = I_A_ID;
					myArmor.Burden = isa.ISBurden;
				    myArmor.Equipment_Slot = isa.EquipmentSlot;
					myArmor.Min_Armor_Rate = (int)isa.Armor.x;
					myArmor.Max_Armor_Rate = (int)isa.Armor.y;
					myArmor.Durability = isa.Durability;
					myArmor.Max_Durability = isa.MaxDurability;
					myArmor.Value = isa.ISValue;
					GameInformation.InventoryArmors.Add (myArmor);
					inv_t++;
				}

				if(GUI.Button(new Rect(225,225,Screen.width / 8, 20),"Additem W"))
				{
					I_W_ID = Random.Range(0,WDB.Count);
					ISWeapon isw = WDB.Get (I_W_ID);
					Weapon myweapon = new Weapon();
					myweapon.ItemID = I_W_ID;
					myweapon.Name = isw.Name;
					myweapon.Burden = isw.ISBurden;
					myweapon.Equipment_Slot = isw.EquipmentSlot;
					myweapon.Min_Damage = isw.MinDamage;
					myweapon.Durability = isw.Durability;
					myweapon.Max_Durability = isw.MaxDurability;
					myweapon.Value = isw.ISValue;
					myweapon.Equipment_Element = isw.EQElement;
					myweapon.Equipment_Type = isw.EquipmentType;
					myweapon.Equipment_Range = isw.EquipmentRange;
					GameInformation.InventoryWeapons.Add (myweapon);
					inv_t++;
				}
				if(GUI.Button(new Rect(225,245,Screen.width / 8, 20),"Additem P"))
				{

					I_P_ID = Random.Range (0, PDB.Count);
					ISPotion isp = PDB.Get (I_P_ID);
					Potion myPotion = new Potion ();
					myPotion.Item_ID = I_P_ID;
					myPotion.Value = isp.ISValue;
					myPotion.Cool_Down = isp.CoolDownTime;
					myPotion.Max_Stack = isp.MaxStack;
					myPotion.Name = isp.Name;
 					GameInformation.InventoryPotions.Add (myPotion);
					inv_t++;

				}
				GUILayout.BeginHorizontal ();
				GUILayout.Space (150);
				GUILayout.Label ("Inv");
				GUILayout.EndHorizontal ();

			//PlayerStats
						GUILayout.BeginVertical ("Box");
			if (GameInformation.Stat_Points > 0) {
					GUILayout.Label ("Player Name : " + GameInformation.PlayerName);
					GUILayout.Label ("Player Level : " + GameInformation.PlayerLevel.ToString ());
					GUILayout.Label ("Stat Points : "+GameInformation.Stat_Points.ToString());
					GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Vitality : " + GameInformation.Vitality);

					if (GUILayout.Button ("-")) {
						GameInformation.Vitality--;
						GameInformation.Stat_Points++;
						if (GameInformation.Vitality < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Vitality++;
//							PlayerUIManager.StatAdjustment ();

						}
					}
					if (GUILayout.Button ("+")) {
						GameInformation.Vitality++;
						GameInformation.Stat_Points--;
//						PlayerUIManager.StatAdjustment ();


					}
					GUILayout.EndHorizontal ();
					GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Endurance : " + GameInformation.Endurance);

					if (GUILayout.Button ("-")) {
						GameInformation.Endurance--;
						GameInformation.Stat_Points++;
						if (GameInformation.Endurance < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Endurance++;
//							PlayerUIManager.StatAdjustment ();

						}
					}
					if (GUILayout.Button ("+")) {
						GameInformation.Endurance++;
						GameInformation.Stat_Points--;
//						PlayerUIManager.StatAdjustment ();

					}
					GUILayout.EndHorizontal ();
					GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Dexetry : " + GameInformation.Dexetry);

					if (GUILayout.Button ("-")) {
						GameInformation.Dexetry--;
						GameInformation.Stat_Points++;
						if (GameInformation.Dexetry < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Dexetry++;
						}
					}
					if (GUILayout.Button ("+")) {
						GameInformation.Dexetry++;
						GameInformation.Stat_Points--;
					}

					GUILayout.EndHorizontal ();
					GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Intellect : " + GameInformation.Intellect);

					if (GUILayout.Button ("-")) {
						GameInformation.Intellect--;
						GameInformation.Stat_Points++;
						if (GameInformation.Intellect < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Intellect++;
//							PlayerUIManager.StatAdjustment ();

						}
					}
					if (GUILayout.Button ("+")) {
						GameInformation.Intellect++;
						GameInformation.Stat_Points--;
//						PlayerUIManager.StatAdjustment ();

					}
					GUILayout.EndHorizontal ();
					GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Strenght : " + GameInformation.Strength);

					if (GUILayout.Button ("-")) {
						GameInformation.Strength--;
						GameInformation.Stat_Points++;
						if (GameInformation.Strength < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Strength++;
						}
					}
					if (GUILayout.Button ("+")) {
						GameInformation.Strength++;
						GameInformation.Stat_Points--;
					}
					GUILayout.EndHorizontal ();
					GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Aim : " +GameInformation.Aim);

					if (GUILayout.Button ("-")) {
						GameInformation.Aim--;
						GameInformation.Stat_Points++;
						if (GameInformation.Aim < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Aim++;
						}

					} 
					if (GUILayout.Button ("+")) {
						GameInformation.Aim++;
						GameInformation.Stat_Points--;

					} 
					GUILayout.EndHorizontal ();
					GUILayout.Label ( "Money : " + GameInformation.Currency.ToString ());
					GUILayout.Label ( "RequiredXp : " + GameInformation.RequiredXP.ToString ());
					GUILayout.Label ( "Current Xp : " + GameInformation.CurrentXp.ToString ());
					GUILayout.EndVertical ();

				}


					//Statpoints Controls if stat points reach zero
				if (GameInformation.Stat_Points == 0) {
					GUILayout.Label ("Player Name : " + GameInformation.PlayerName);
					GUILayout.Label ("Player Level : " + GameInformation.PlayerLevel.ToString ());
					GUILayout.Label ("Stat Points : "+GameInformation.Stat_Points.ToString());
						GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Vitality : " + GameInformation.Vitality);

						if (GUILayout.Button ("-")) {
						GameInformation.Vitality--;
						GameInformation.Stat_Points++;
						if (GameInformation.Vitality < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Vitality++;
						}
						}
						GUILayout.EndHorizontal ();
						GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Endurance : " + GameInformation.Endurance);

						if (GUILayout.Button ("-")) {
						GameInformation.Endurance--;
						GameInformation.Stat_Points++;

						if (GameInformation.Endurance < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Endurance++;
						}
						}
						GUILayout.EndHorizontal ();
						GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Dexetry : " + GameInformation.Dexetry);

						if (GUILayout.Button ("-")) {
						GameInformation.Dexetry--;
						GameInformation.Stat_Points++;
						if (GameInformation.Dexetry < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Dexetry++;
						}
						}
						GUILayout.EndHorizontal ();
						GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Intellect : " + GameInformation.Intellect);

						if (GUILayout.Button ("-")) {
						GameInformation.Intellect--;
						GameInformation.Stat_Points++;
						if (GameInformation.Intellect < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Intellect++;
						}
						}
						GUILayout.EndHorizontal ();
						GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Strength : " + GameInformation.Strength);

						if (GUILayout.Button ("-")) {
						GameInformation.Strength--;
						GameInformation.Stat_Points++;
						if (GameInformation.Strength < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Strength++;
						}
						}
						GUILayout.EndHorizontal ();
						GUILayout.BeginHorizontal ( );
					GUILayout.Label ("Aim : " + GameInformation.Aim);

						if (GUILayout.Button ("-")) {
						GameInformation.Aim--;
						GameInformation.Stat_Points++;
						if (GameInformation.Aim < 0) 
						{
							GameInformation.Stat_Points--;
							GameInformation.Aim++;
						}

						} 
						GUILayout.EndHorizontal ();
					GUILayout.Label ( "Money : " + GameInformation.Currency.ToString ());
					GUILayout.Label ( "RequiredXp : " + GameInformation.RequiredXP.ToString ());
					GUILayout.Label ( "Current Xp : " + GameInformation.CurrentXp.ToString ());

						GUILayout.EndVertical ();
					}
				//PauseMenu Controls
			if (GUI.Button (new Rect (225, 305, Screen.width / 8, 20), "Resume")) {
			if (!CameraManipulation.x) {
				CameraManipulation.z = false;
				CameraManipulation.pause = false;
			}if (CameraManipulation.x) {
				CameraManipulation.z = true;
			}
			PlayerUIManager.StatAdjustment ();
 			}
			if (GUI.Button (new Rect (225, 325, Screen.width / 8, 20), "Exit")) {
				Time.timeScale = 1;
				Application.LoadLevel ("MainMenu");
				DestroyObject (gameObject);
 			}
				if (GUI.Button (new Rect (225, 350, Screen.width / 8, 20), "Save")) {
				SaveInformation.Save ();
					Debug.Log (GameInformation.RequiredXP);
			}

				WindowPlaceHolder = GUILayout.Window (WindowID,WindowPlaceHolder,_inventory,"Inventory");

			
			}


		

		
	 
	public enum Equiping{
		Equip,
		UnEquip
	}
	Equiping EQ;
		public  void _inventory(int id )
		{
			Vector2 _scroll_view = Vector2.zero;
			bool MaxedOutInventory = false;
			GUILayout.BeginHorizontal ("Box");
			if(GUILayout.Button("Weapons")){
				inv_T = inventory_tabs.Weapons;
			}
			if(GUILayout.Button("Armors")){
				inv_T = inventory_tabs.Armors;
			}
			if(GUILayout.Button("Potions")){
				inv_T = inventory_tabs.Potions;
			}
			GUILayout.EndHorizontal ();
			if (inv_t == 79) {
				MaxedOutInventory = true;
			}

 			switch (inv_T) {
			case inventory_tabs.Weapons:
				inventory_Tab_W ();
				break;
			case inventory_tabs.Potions:
				inventory_Tab_P ();
				break;
			default:
				inventory_Tab_A ();
				break;
			}
			 
		 




			GUI.DragWindow ();
		}
		public void inventory_Tab_A(){
			for (int cnt = 0; cnt < GameInformation.InventoryArmors.Count; cnt++) {
				GUILayout.Box (GameInformation.InventoryArmors[cnt].Name + " : "+ GameInformation.InventoryArmors[cnt].Equipment_Slot);
			}
		}
		public void inventory_Tab_W(){
		bool equiped = false;
		Vector2 _scrollpos = Vector2.zero;

		for (int cnt = 0; cnt < GameInformation.InventoryWeapons.Count; cnt++) {
			GUILayout.BeginHorizontal ("Box");
			if (GUILayout.Button ("E1 : "+GameInformation.InventoryWeapons[cnt].Name)) {
					GameInformation.InventoryWeapons.Add (PlayerUIManager.weapon1);
					PlayerUIManager.weapon1 = GameInformation.InventoryWeapons [cnt];
					Debug.Log ("Weapon Equiped 1");
					GameInformation.InventoryWeapons.RemoveAt (cnt);

				}


			if (GUILayout.Button ("E2"+GameInformation.InventoryWeapons[cnt].Name)) {
					GameInformation.InventoryWeapons.Add (PlayerUIManager.weapon2);
					PlayerUIManager.weapon2 = GameInformation.InventoryWeapons [cnt];
					Debug.Log ("Weapon Equiped 2");
					GameInformation.InventoryWeapons.RemoveAt (cnt);
				}

				if (GUILayout.Button ("E3")) {
					GameInformation.InventoryWeapons.Add (PlayerUIManager.weapon3);
					PlayerUIManager.weapon3 = GameInformation.InventoryWeapons [cnt];
					Debug.Log ("Weapon Equiped 3");
					GameInformation.InventoryWeapons.RemoveAt (cnt);

				}
			 
		 
			GUILayout.EndHorizontal ();
			}
 

		}

		public void inventory_Tab_P(){
		for (int cnt = 0; cnt < GameInformation.InventoryPotions.Count; cnt++) {
			GUILayout.Box (GameInformation.InventoryPotions [cnt].Name + " : " + GameInformation.InventoryPotions [cnt].Current_Stacks.ToString () + " : " + GameInformation.InventoryPotions [cnt].Cool_Down.ToString ());
			if (GameInformation.InventoryPotions.Contains (GameInformation.InventoryPotions [cnt])) {
				GameInformation.InventoryPotions [cnt].Current_Stacks++;
				GameInformation.InventoryPotions.Remove(GameInformation.InventoryPotions[cnt]);
 			}
//			if (GameInformation.InventoryPotions.Capacity > 2) {
//				if (GameInformation.InventoryPotions [cnt].Name == GameInformation.InventoryPotions [cnt - 1].Name) {
//					GameInformation.InventoryPotions [cnt].Current_Stacks++;
//					GameInformation.InventoryPotions.RemoveAt (cnt - 1);
//				}
//			}		
		}

	}

		


	}

 