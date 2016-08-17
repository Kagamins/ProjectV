using UnityEngine;
using System.Collections;
[System.Serializable]
public class BasePlayer  {
	private string _playerName;
	private int _playerlevel;
	private BaseCharacterClass _playerclass;
	private GameObject _playerObject;
	//Stats
	private int _vitality; //Modifies Health
	private int _intellect; // Modifies Mana and Damage for Mage
	private int _strength; //Modifies Damage for Brawler/Warrior
	private int _endurance;//Modifies Stamina
	private int _dextery; //Modifies Damage for Warrior
	private int _Aim;     //modifies Critical Dmg for all classes
	private int _currentxp;
	private int _requiredxp;

	public string PlayerName{
		get {return _playerName;}
		set{_playerName = value;}
	}
	//Related to Leveling up
	public int CurrentXp = 0;
	//Will Change Depending on level
	public int RequiredXp = 100;
	//The main PlayerLevel
	public int PlayerLevel{
		get {return _playerlevel;}
		set{_playerlevel = value;}
	}

	public int Aim {
		get{return _Aim;}
		set{_Aim = value;}
	}

	public BaseCharacterClass PlayerClass {
		get { return _playerclass;}
		set{ _playerclass = value;}
	}
	public int Vitality{
			get {return _vitality;}
			set{_vitality = value;}
		}
	public int Intellect{
			get {return _intellect;}
			set{_intellect = value;}
		}
	public int Strength{
			get {return _strength;}
			set{_strength = value;}
		}
	public int Endurance{
			get {return _endurance;}
			set{_endurance = value;}
		}
	public int Dexetry{
			get {return _dextery;}
			set{_dextery = value;}
		}
	public GameObject PlayerObject{
		get{return _playerObject;}
		set{_playerObject = value;}
	}
}
