using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CreateCharacter : MonoBehaviour {


	public BasePlayer newPlayer;




	// Use this for initialization
	void start () {
		newPlayer = new BasePlayer ();


	}
	
	// Update is called once per frame
	void Update () {

	//
		}
	public void CharacterName(string x){
		 
		newPlayer.PlayerName = x;
		GameInformation.PlayerName = x;
		Debug.Log (x);
	}
//	public void ISMage(){
//		//isMageClass = true;
//		newPlayer.PlayerClass = new BaseMage();
//
//		Store ();
//		
//	}
//	public void ISWarrior(){
//		//isWarriorClass = true;
//		newPlayer.PlayerClass = new BaseWarrior();
//		Store ();
//		
//	}
//	public void ISRanger(){
//		//isRangerClass = true;
//		newPlayer.PlayerClass =new BaseRanger();
//		Store ();
//		
//	}
//	public void ISBrawler(){
//		//isBrawlerClass = true;
//		newPlayer.PlayerClass =new BaseBrawler();
//		Store ();
//		
//	}

	public void Store(){
//		newPlayer.Aim = newPlayer.PlayerClass.Aim;
//		newPlayer.Endurance = newPlayer.PlayerClass.Endurance;
//		newPlayer.Vitality = newPlayer.PlayerClass.Vitality;
//		newPlayer.Intellect = newPlayer.PlayerClass.Intellect;
//		newPlayer.Dexetry = newPlayer.PlayerClass.Dexetry;
//		newPlayer.Strength = newPlayer.PlayerClass.Strength;
		//Stores info to the Gameinformation
//		GameInformation.PlayerDescription = newPlayer.PlayerClass.CharacterClassDescription;
//		GameInformation.PlayerClass = newPlayer.PlayerClass;
		GameInformation.PlayerName = newPlayer.PlayerName;
		GameInformation.Endurance = newPlayer.Endurance;
		GameInformation.Vitality = newPlayer.Vitality;
		GameInformation.Aim = newPlayer.Aim;
		GameInformation.Strength = newPlayer.Strength;
		GameInformation.Intellect = newPlayer.Intellect;
		GameInformation.Dexetry = newPlayer.Dexetry;
//		GameInformation.PlayerClassName = newPlayer.PlayerClass.CharacterClassName;
		GameInformation.PlayerLevel = newPlayer.PlayerLevel;
		GameInformation.CurrentXp = newPlayer.CurrentXp;
		GameInformation.RequiredXP = newPlayer.RequiredXp;
	}

	}



