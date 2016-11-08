using UnityEngine;
using System.Collections;
public class AddExperience  {

	private static int XptoGive;
	private static LevelUp LevelUpScript = new LevelUp();
	public static void AddExp() {
		XptoGive =  GameInformation.PlayerLevel* Random.Range (10, 15);
		GameInformation.CurrentXp += XptoGive;
		if(GameInformation.CurrentXp>=GameInformation.RequiredXP){
			//Level Up
			LevelUp.HaveLeveled = true;
			LevelUpScript.LevelUpCharacter();
			PlayerUIManager.statIncrease();
			PlayerUIManager.StatAdjustment ();
			//Level Up Script
		}
		Debug.Log (XptoGive);
			}
	 
}
