using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
public interface IISObject  {
	//name
	//value - MythStone
	//icon
	//burden
	//qualitylevel
	string Name{ get; set;}
	int ISValue{ get; set;}
	Sprite ISIcon{ get; set;}
	int ISBurden{ get; set;}
	ISQuality Quality{ get; set;}

	//to other interfaces
	//equip
	//Questitem flags
	//Durabilitty
	//TakeDamage
	//prefab

}
}