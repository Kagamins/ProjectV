using UnityEngine;
using System.Collections;
public class LevelUp  {
	public int LevelCap = 50;
	public static bool HaveLeveled= false;
	public    void LevelUpCharacter(){
		//Check if Currentxp > required xp
		if (GameInformation.CurrentXp > GameInformation.RequiredXP) {
			GameInformation.CurrentXp -= GameInformation.RequiredXP;
		
		} else {
			GameInformation.CurrentXp = 0;
		}
		if (GameInformation.PlayerLevel < LevelCap) {
			GameInformation.PlayerLevel ++;
			GameInformation.Stat_Points += 5;

			PlayerUIManager.Health = PlayerUIManager.maxHealth;
			PlayerUIManager.Mana = PlayerUIManager.MaxMana;
			PlayerUIManager.Stamina = PlayerUIManager.MaxStamina;
		} else {
			GameInformation.PlayerLevel = LevelCap;
		}
		//Give Player Stat Points

		//Give Abillity
		//Determine next Required Xp
		DetermineRequiredXp ();
	}
	private void DetermineRequiredXp(){
		//Gets required exp
		int temp = (GameInformation.PlayerLevel * 120) + 15;
		GameInformation.RequiredXP = temp;
		//sets required exp
	}
//	private void WarriorStats(){
//
//		GameInformation.Strength += 5;
//		GameInformation.Vitallty += 25;
//		GameInformation.Dextry += 2;
//		GameInformation.Aim += 3;
//		GameInformation.Endurance += 10;
//		GameInformation.Intellect += 2;
//
//	}
//	private void MageStats(){
//		
//		GameInformation.Strength += 2;
//		GameInformation.Vitallty += 5;
//		GameInformation.Dextry += 2;
//		GameInformation.Aim += 3;
//		GameInformation.Endurance += 10;
//		GameInformation.Intellect += 20;
//		
//	}
//	private void RangerStats(){
//		
//		GameInformation.Strength += 5;
//		GameInformation.Vitallty += 15;
//		GameInformation.Dextry += 20;
//		GameInformation.Aim += 30;
//		GameInformation.Endurance += 5;
//		GameInformation.Intellect += 2;
//		
//	}
//	private void BrawlerStats(){
//		
//		GameInformation.Strength += 25;
//		GameInformation.Vitallty += 15;
//		GameInformation.Dextry += 2;
//		GameInformation.Aim += 20;
//		GameInformation.Endurance += 10;
//		GameInformation.Intellect += 5;
//		
//	}
}
