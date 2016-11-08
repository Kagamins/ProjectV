using UnityEngine;
using System.Collections;
using ProjectV.ItemSystem;
using System.Runtime.Serialization;
//[RequireComponent(typeof(BoxCollider))] 
[System.Serializable]
public class Weapon : MonoBehaviour {

	[SerializeField]public string Name;
	[SerializeField]public int ItemID;
//	public Sprite Icon;
	[SerializeField]public int Value;
	[SerializeField]public int Burden;
//	public Sprite Quality;
	[SerializeField]public int Min_Damage;
	[SerializeField]public int Max_Durability;
	[SerializeField]public int Durability;
	[SerializeField]public EQSlot Equipment_Slot;
	[SerializeField]public EQType Equipment_Type;
	[SerializeField]public EquipmentElement Equipment_Element;
	[SerializeField]public EQRange Equipment_Range;

//	public void OnCollisonEnter(Collision other){
//		if (other.gameObject.tag == "MobEnemy") {
//			other.gameObject.GetComponent<Enemy>().Hit(Random.Range(Min_Damage, Min_Damage+ GameInformation.PlayerLevel*12*GameInformation.Aim* GameInformation.Dexetry));
//		}

	
//	}
}
