using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
public interface IISEquipable  
	{
		//EqupmentSlot
		ISEquipmentSlot EquipmentSlot{ get; set;}

		// EquipmentSlot{ get; set;}
		bool Equip();


}
}