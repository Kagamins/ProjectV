using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseWarrior : BaseCharacterClass {
	public BaseWarrior(){
		CharacterClassName = "Warrior";
		CharacterClassDescription = "A strong and powerful warrior";
		Vitality = 20;
		Endurance = 14;
		Dexetry = 10;
		Intellect = 4;
		Strength = 20;
		Aim = 15;
	}

}
