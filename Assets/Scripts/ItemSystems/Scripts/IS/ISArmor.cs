#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
	[System.Serializable]
	public class ISArmor : ISObject,IISArmor,IISDestructable,IISGameObject {
		[SerializeField]int _currentArmor;
		[SerializeField]int _maxArmor;

		[SerializeField]int _durability;
		[SerializeField]int _maxdurability;
		[SerializeField]GameObject _prefab;
		
		public EQSlot EquipmentSlot;
		public ISArmor ()
		{
			_currentArmor = 0;
			_maxArmor = 0;
			_durability = 100;
			_maxdurability = 100;

			EquipmentSlot = EQSlot.Feet;
		}


		public Vector2 Armor {
			get {
				return new Vector2(_currentArmor,_maxArmor);
			}
			set {
				//Current Armor is Higher than 0
				//Max Armor is Higher than Current Armor
				if(value.x<0)
					value.x = 0;
				if (value.y<1)
					value.y = 1;
				if(value.x>value.y)
					value.x = value.y;
				_currentArmor = (int)value.x;
				_maxArmor = (int)value.y;

			}
		}


		public ISArmor(ISArmor armor)
		{
			Clone (armor);
		}
		
		public void Clone(ISArmor armor)
		{
			base.Clone (armor);

			_maxArmor = armor._maxArmor;
			_currentArmor = armor._currentArmor;
			_durability = armor.Durability;
			_maxdurability = armor.MaxDurability;
			EquipmentSlot = armor.EquipmentSlot; 
			_prefab = armor.Prefab;
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
		#if UNITY_EDITOR
		public override void OnGUI()
		{
			
			base.OnGUI ();

			_maxArmor =  EditorGUILayout.IntField ("Armor Rating Max", _maxArmor);
			_currentArmor = EditorGUILayout.IntField ("Armor Rating Min", _currentArmor);
			_maxdurability = EditorGUILayout.IntField ("MaxDurability", _maxdurability);
			_durability = EditorGUILayout.IntField ("Durability", _durability);
			DisplayEquipmentSlot ();
			DisplayPrefab ();
			
		}
		public void DisplayEquipmentSlot()
		{	EquipmentSlot = (EQSlot)EditorGUILayout.EnumPopup ("Equipment Slot", EquipmentSlot);
			
		}
		public void DisplayPrefab()
		{	
			_prefab = EditorGUILayout.ObjectField ("Prefab",_prefab,typeof(GameObject),false)as GameObject;
			
		}
		#endif

	}

}
