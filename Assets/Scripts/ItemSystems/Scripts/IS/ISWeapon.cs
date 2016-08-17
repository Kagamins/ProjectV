#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
	[System.Serializable]
public class ISWeapon : ISObject,IISWeapon,IISDestructable,IISGameObject {
		[SerializeField] int _mindamage;
		[SerializeField]int _durability;
		[SerializeField]int _maxdurability;

		[SerializeField]GameObject _prefab;

		public EQSlot EquipmentSlot;
		public EquipmentElement EQElement;
		public EQRange EquipmentRange;
		public EQType EquipmentType;
		public ISWeapon()
		{
			_mindamage = 0;
			_durability = 100;
			_durability = 1;

			EquipmentSlot = EQSlot.Feet;

		}

		public ISWeapon(ISWeapon weapon)
		{
			Clone (weapon);
		}

		public void Clone(ISWeapon weapon)
		{
			base.Clone (weapon);

			_mindamage = weapon.MinDamage;
			_durability = weapon.Durability;
			_maxdurability = weapon.MaxDurability;
			EquipmentSlot = weapon.EquipmentSlot; 
			_prefab = weapon.Prefab;
		}





		

		//Weapon
		public int MinDamage
		{
			get{return _mindamage;}
			set{_mindamage = value;}
		}
		public int Attack()
		{
			throw new System.NotImplementedException ();
		}


		public void TakeDamage (int amount)
		{
			_durability -= amount;
			if (_durability < 0)
				_durability = 0;
			if (_durability == 0)
				Break ();
		}
		public void Repair ()
		{
			_maxdurability--;
			if(_maxdurability>0)

			_durability = _maxdurability;
		}
		//reduce durability to 0
		public void Break ()
		{
			_durability = 0;
		}
		public int Durability {
			get {return _durability;}
		}
		public int MaxDurability {
			get { return _maxdurability;}
		}






		public GameObject Prefab {
			get {

				return _prefab;}

		}
		//this code will go to a new script
#if UNITY_EDITOR
		public override void OnGUI()
		{
			bool isAmmo = false;
			base.OnGUI ();
			_mindamage = EditorGUILayout.IntField ("Minimum Damage", _mindamage);
			_maxdurability = EditorGUILayout.IntField ("MaxDurability", _maxdurability);
			_durability = EditorGUILayout.IntField ("Durability", _durability);
			DisplayEquipmentSlot ();
			DisplayElement ();
			DisplayEquipmentRange ();
			DisplayEquipmentType ();
			DisplayPrefab ();
		}
		public void DisplayEquipmentSlot()
		{	EquipmentSlot = (EQSlot)EditorGUILayout.EnumPopup ("Equipment Slot", EquipmentSlot);

		}
		public void DisplayElement()
		{
			EQElement = (EquipmentElement)EditorGUILayout.EnumPopup ("Equipment Element", EQElement);
		}
		public void DisplayEquipmentType()
		{
			EquipmentType = (EQType)EditorGUILayout.EnumPopup ("Equipment Type",EquipmentType);
		}
		public void DisplayEquipmentRange()
		{
			EquipmentRange = (EQRange)EditorGUILayout.EnumPopup ("Equipment Range", EquipmentRange);
		}
		public void DisplayPrefab()
		{	
			_prefab = EditorGUILayout.ObjectField ("Prefab",_prefab,typeof(GameObject),false)as GameObject;

		}
#endif
	}

}