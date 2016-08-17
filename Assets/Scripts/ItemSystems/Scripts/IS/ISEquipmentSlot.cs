using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
public class ISEquipmentSlot : IISEquipmentSlot {
		[SerializeField]string _name;

		public ISEquipmentSlot()
		{
			_name = "Name Me";
		}
		public string Name {
			get {return _name;}
			set {_name = value;}
		}



}
}