using UnityEngine;
using System.Collections;
using ProjectV.ItemSystem;
public class TreasureChest : MonoBehaviour {
 	public static int W_ItemID,A_ItemID,P_ItemID;
 	Animator _Animator;
	public ISWeaponDatabase WDB;
	public ISArmorDatabase ADB;
	public ISPotionDatabase PDB;
	void Awake () {
		PDB = Resources.Load ("PotionDB")as ISPotionDatabase;
 		WDB = Resources.Load ("WeaponDB")as ISWeaponDatabase;
 		ADB = Resources.Load ("ArmorDB")as ISArmorDatabase;
		_Animator = GetComponent<Animator> ();	
		W_ItemID = Random.Range (0, WDB.Count );
		A_ItemID = Random.Range (0, ADB.Count );
		P_ItemID = Random.Range (0, PDB.Count );
		_Animator.SetBool ("_Open",PlayerUIManager.loot_enabled);
	}

 	 

	void OnMouseEnter(){
		
		PlayerUIManager.loot_enabled = true;
	
	}

}
