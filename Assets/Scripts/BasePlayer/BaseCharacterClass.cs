using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseCharacterClass  {
	private string _characterClassName;
	private string _characterClassDescription;
	//Statistics
	private int _vitality;
	private int _intellect;
	private int _strength;
	private int _endurance;
	private int _dextery;
	private int _aim;

	public string CharacterClassName{
		get {return _characterClassName;}
		set{_characterClassName = value;}
		}
	public string CharacterClassDescription{
		get {return _characterClassDescription;}
		set{_characterClassDescription = value;}
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
	public int Aim{
		get{return _aim;}
		set{_aim = value;}

	}


}
