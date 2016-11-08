using UnityEngine;

using System.Collections;
namespace ProjectV.ItemSystem{
	[System.Serializable]
public class ISQuality : IISQuality {

	[SerializeField]string _name;
	[SerializeField]Sprite _icon;

	  public ISQuality(){
		_icon = new Sprite ();
		_name = "";
	}
		public ISQuality(string name, Sprite icon)
		{
			_name = name;
			_icon = icon;
		}
	public string Name {
		get {
			return _name;
			
		}
		set {_name = value;
			
		}
	}

	public Sprite Icon {
		get {return _icon;
			
		}
		set {_icon = value;
			
		}
	}

				}
}