using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using ProjectV.ItemSystem;
[System.Serializable]
public class Armor : MonoBehaviour {
	
	public string Name;
	public int ItemID;
//	public Sprite Icon;
	public int Value;
	public int Burden;
//	public Sprite Quality;
	public int Min_Armor_Rate;
	public int Max_Armor_Rate;
	public int Max_Durability;
	public int Durability;
	public EQSlot Equipment_Slot;
}
