using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseRanger : BaseCharacterClass {
	public BaseRanger(){
		CharacterClassName = "Ranger";
		CharacterClassDescription = "A Witty Marksman";
		Vitality = 12;
		Endurance = 4;
		Dexetry = 20;
		Intellect = 10;
		Strength = 15;
		Aim = 35;
	}
}
