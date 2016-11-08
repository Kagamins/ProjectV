using UnityEngine;
using System.Collections;
using ProjectV.ItemSystem;
//using UnityEngine.Networking;
public class AlphaMenu : CreateCharacter {

	public GUISkin StyleTest;
	public string Name = "Enter Your Name";
	private bool BGUIEnabled = true;  //for the Main Menu
	private bool MGUIEnabled = false; // for the new Game
	private bool OGUIEnabled = false; // for the OptionsMenu
	private bool AGUIEnabled = false; // for the Music On/ Off Function
	private bool CGUIEnabled = false; // for Online Gameplay Disabled at the moment 
	public static bool HaveLoaded = false;
	public static bool NewGame = false;
	public static int Alloted_points = 100;
	public ISWeaponDatabase WDB;
	public ISArmorDatabase ADB;
	public string X1;
	public string X2;
	public string X3;
	public int cnt1 = 1;
	public int cnt2 = 1;
	public int cnt3 = 1;
	public GameObject x;
	public Material current;
	// Use this for initialization
	void Start () {
		newPlayer.PlayerLevel = 1;
		WDB = Resources.Load ("WeaponDB")as ISWeaponDatabase;

		ADB = Resources.Load ("ArmorDB")as ISArmorDatabase;
	}
	

	 
	void OnGUI()
	{

		GUI.skin = StyleTest;
	GUILayout.BeginArea (new Rect (Screen.width/2, Screen.height/6, Screen.width / 6, Screen.height / 2),"-","Box");
			GUILayout.Label ("MainMenu");
			 
				if(BGUIEnabled)
		{
			if (GUILayout.Button ("NewGame")){
			MGUIEnabled = true;
			BGUIEnabled = false;
		}
		}
				if (MGUIEnabled) {
			Name = GUILayout.TextField(Name,20);
			if (GUILayout.Button ("Start")) {
				NewGame = true;
				GameInformation.Stat_Points = Alloted_points;
				newPlayer.PlayerLevel = 1;
				newPlayer.RequiredXp = 100;
				newPlayer.PlayerName = Name;
				GameInformation.Max_Expertise_Points = 1500;
				for (int cnt = 0; cnt < 3; cnt++) {
					ISWeapon isw = WDB.Get (cnt);
					Weapon myweapon = new Weapon ();
					myweapon.ItemID = cnt;
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
				}

 				Store ();
//				Debug.Log ("PlayerClass" + newPlayer.PlayerClass.CharacterClassName);
				CameraManipulation.pause = false;
				Application.LoadLevel ("SchoolLevel");
			}
			GUILayout.Label ("Alloted Points : "+ Alloted_points);

			GUILayout.BeginVertical ( );
			if (Alloted_points > 0) {
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Vitality : " + newPlayer.Vitality);
				if (GUILayout.Button ("+")) {
					newPlayer.Vitality++;
					Alloted_points--;
				}
				if (GUILayout.Button ("-")) {
					if (newPlayer.Vitality > 0) {
						newPlayer.Vitality--;
						Alloted_points++;
					}
				}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Endurance : " + newPlayer.Endurance);
				if (GUILayout.Button ("+")) {
					newPlayer.Endurance++;
					Alloted_points--;
				}
				if (GUILayout.Button ("-")) {
					if (newPlayer.Endurance > 0)
					{
						newPlayer.Endurance--;
						Alloted_points++;
					}
				}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Dexetry : " + newPlayer.Dexetry);
				if (GUILayout.Button ("+")) {
					newPlayer.Dexetry++;
					Alloted_points--;
				}
				if (GUILayout.Button ("-")) {
					if (newPlayer.Dexetry > 0) {
						newPlayer.Dexetry--;
						Alloted_points++;
					}
				}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Intellect : " + newPlayer.Intellect);
				if (GUILayout.Button ("+")) {
					newPlayer.Intellect++;
					Alloted_points--;
				}
				if (GUILayout.Button ("-")) {
					if (newPlayer.Intellect > 0) {
						newPlayer.Intellect--;
						Alloted_points++;
					}
					}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Strenght : " + newPlayer.Strength);
				if (GUILayout.Button ("+")) {
					newPlayer.Strength++;
					Alloted_points--;
				}
				if (GUILayout.Button ("-")) {
					if (newPlayer.Strength > 0) {
						newPlayer.Strength--;
						Alloted_points++;
					}}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Aim : " + newPlayer.Aim);
				if (GUILayout.Button ("+")) {
					newPlayer.Aim++;
					Alloted_points--;
				}
				if (GUILayout.Button ("-")) {
					if (newPlayer.Aim>0) {
						newPlayer.Aim--;
						Alloted_points++;
					}
				} 
				GUILayout.EndHorizontal ();
				GUILayout.EndVertical ();
			}


			GUILayout.BeginVertical ( );
			if (Alloted_points == 0) {
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Vitality : " + newPlayer.Vitality);

				if (GUILayout.Button ("-")) {
					if (newPlayer.Vitality > 0) {
						newPlayer.Vitality--;
						Alloted_points++;
					}}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Endurance : " + newPlayer.Endurance);

				if (GUILayout.Button ("-")) {
					if (newPlayer.Endurance > 0) {
						newPlayer.Endurance--;
						Alloted_points++;
					}
				}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Dexetry : " + newPlayer.Dexetry);

				if (GUILayout.Button ("-")) {
					if (newPlayer.Dexetry > 0) {
						newPlayer.Dexetry--;
						Alloted_points++;
					}
				}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Intellect : " + newPlayer.Intellect);

				if (GUILayout.Button ("-")) {
					if (newPlayer.Intellect > 0) {
						newPlayer.Intellect--;
						Alloted_points++;
					}
				}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Strength : " + newPlayer.Strength);

				if (GUILayout.Button ("-")) {
					if (newPlayer.Strength > 0) {
						newPlayer.Strength--;
						Alloted_points++;
					}
				}
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ( );
				GUILayout.Label ("Aim : " + newPlayer.Aim);

				if (GUILayout.Button ("-")) {
					if (newPlayer.Aim>0) {
						if (newPlayer.Aim > 0) {
							newPlayer.Aim--;
							Alloted_points++;
						}
					}

				} 
				GUILayout.EndHorizontal ();
				GUILayout.EndVertical ();
			}
			GUILayout.BeginHorizontal ();

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

			GUILayout.EndHorizontal ();
			if(GUILayout.Button("Back"))
				{
					MGUIEnabled = false;
					BGUIEnabled = true;
				}
			}

		if (BGUIEnabled) {
//			if(GUILayout.Button("Connect"))
//			{
//				BGUIEnabled = false;
//				CGUIEnabled = true;
////				Application.LoadLevel("");
//			}
			if (GUILayout.Button ("Load Game"))
			{
				HaveLoaded = true;
				LoadInformation.Load ();

				Application.LoadLevel ("SchoolLevel");
			}
			if (GUILayout.Button ("Options")) 
			{
				OGUIEnabled = true;
				BGUIEnabled = false;
			}
		}
				if(OGUIEnabled){

					GUILayout.Label ("Music");
					if(!AGUIEnabled)
						{
						if (GUILayout.Button ("Off")) {
							
							AudioListener.pause = true;
								AGUIEnabled = true;
							
						}
						}
						if(AGUIEnabled){
						if (GUILayout.Button ("On")) {
							
							AudioListener.pause = false;
								AGUIEnabled = false;
							
						}
						}
			GUILayout.Label ("Music Volume");
			GUILayout.BeginHorizontal("Box");
			if (GUILayout.Button ("+")) {
				
				AudioListener.volume += 0.1f;
			
				
			}
			if (GUILayout.Button ("-")) {
				
				AudioListener.volume -= 0.1f;
				
				
			}
			GUILayout.EndHorizontal();
					if (GUILayout.Button ("Back")) {
						
						BGUIEnabled = true;
						OGUIEnabled = false;
						

					
				}
				}
		//Associated with the MainMenu 
				if (BGUIEnabled)
		{
			if (GUILayout.Button ("Wipe Save")) 
			{
				PlayerPrefs.DeleteAll ();
			}
			if (GUILayout.Button ("Quit")) 
			{
				Application.Quit ();
			}
		}
		//Associated with the Connect Button 
//		if (CGUIEnabled)
//		{
//			Name = GUILayout.TextField(Name,20);
//			if (GUILayout.Button ("Warrior")) {
//				ISWarrior ();
//				newPlayer.PlayerLevel = 1;
//				newPlayer.RequiredXp = 100;
//				newPlayer.PlayerName = Name;
//				Store ();
//				Debug.Log ("PlayerClass" + newPlayer.PlayerClass.CharacterClassName);
//				Application.LoadLevel ("SchoolNetworkingTest");
//				
//				
//			}
//			if (GUILayout.Button ("Mage")) {
//				ISMage ();
//				newPlayer.PlayerLevel = 1;
//				newPlayer.RequiredXp = 100;
//				newPlayer.PlayerName = Name;
//				Store ();
//				Debug.Log ("PlayerClass" + newPlayer.PlayerClass.CharacterClassName);
//				Application.LoadLevel ("SchoolNetworkingTest");
//				
//			}
//			if (GUILayout.Button ("Ranger")) {
//				ISRanger ();
//				newPlayer.PlayerLevel = 1;
//				newPlayer.RequiredXp = 100;
//				newPlayer.PlayerName = Name;
//				Store ();
//				Debug.Log ("PlayerClass" + newPlayer.PlayerClass.CharacterClassName);
//				Application.LoadLevel ("SchoolNetworkingTest");
//			}
//			if (GUILayout.Button ("Brawler")) {
//				ISBrawler ();
//				newPlayer.RequiredXp = 100;
//				newPlayer.PlayerLevel = 1;
//				newPlayer.PlayerName = Name;
//				Store ();
//				Debug.Log ("PlayerClass" + newPlayer.PlayerClass.CharacterClassName);
//				Application.LoadLevel ("SchoolNetworkingTest");
//				
//			}
//			
//			if (GUILayout.Button ("Load Game"))
//			{
//				HaveLoaded = true;
//				LoadInformation.Load ();
//				
//				Application.LoadLevel ("SchoolLevel");
//			}
//			
//			if(GUILayout.Button("Back"))
//			{
//				CGUIEnabled = false;
//				BGUIEnabled = true;
//			}
//		}
			GUILayout.EndArea ();
		}
	void Update(){
		Time.timeScale = 1;
		ISWeapon W1 = WDB.Get (cnt1);
		X1 = W1.Name;
		ISWeapon W2 = WDB.Get (cnt2);
		X2 = W2.Name;
		ISWeapon W3 = WDB.Get (cnt3);
		X3 = W3.Name;
//		if (Input.GetMouseButtonDown (0)) {
//			Instantiate (x, MenuCubes.cube_pos.position, MenuCubes.cube_pos.rotation);
//		}

	}
	}

