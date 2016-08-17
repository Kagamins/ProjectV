using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
public interface IISPotion  {

	
		//healing amount
		int HealingAmount{ get; set;}
		//CoolDown
		float CoolDownTime{ get; set;}
	}
}
