using UnityEngine;
using System.Collections;
namespace ProjectV.ItemSystem{
public interface IISStackable  {
		int Stack(int amount); //default value of items
		int MaxStack{ get;}
}
}