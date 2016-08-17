using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseBrawler : BaseCharacterClass {
	public BaseBrawler(){
		CharacterClassName = "Brawler";
		CharacterClassDescription = "A Reckless FistFighter";
		Vitality = 12;
		Endurance = 20;
		Dexetry = 10;
		Intellect = 5;
		Strength = 30;
		Aim = 20;
	}
}

