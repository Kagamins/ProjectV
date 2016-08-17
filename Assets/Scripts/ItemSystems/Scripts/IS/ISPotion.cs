#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
	[System.Serializable]
public class ISPotion : ISObject,IISPotion,IISStackable  {
		#region IISPotion implementation
		[SerializeField]int _healingAmount;
		[SerializeField]float _cooldowntime;
		[SerializeField]int _maxstack;
		public int HealingAmount {
			get {return _healingAmount;}
			set {_healingAmount = value;}
		}

		public float CoolDownTime {
			get {return _cooldowntime;}
			set {_cooldowntime = value;}
		}

		#endregion

		#region IISStackable implementation

		public int Stack (int amount)
		{
			throw new System.NotImplementedException ();
		}

		public int MaxStack {
			get {return _maxstack;}
		}

		#endregion
#if UNITY_EDITOR
		public override void OnGUI()
		{
			
			base.OnGUI ();
			
			_healingAmount =  EditorGUILayout.IntField ("Healing Amount", _healingAmount);
			_cooldowntime = EditorGUILayout.FloatField ("CoolDown", _cooldowntime);
			_maxstack = EditorGUILayout.IntField ("Max Stacks", _maxstack);

			
		}
#endif

	
	
	}
}
