using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseMage : BaseCharacterClass {
	public  BaseMage(){
		CharacterClassName = "Mage";
		CharacterClassDescription = "A Witty mage";
		Vitality = 12;
		Endurance = 4;
		Dexetry = 15;
		Intellect = 20;
		Strength = 10;
		Aim = 20;
	}



}
