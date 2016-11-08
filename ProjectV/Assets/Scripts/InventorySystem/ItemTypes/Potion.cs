using UnityEngine;
using System.Collections;
[System.Serializable]
public class Potion : MonoBehaviour {
	[SerializeField]public string Name;
	[SerializeField]public int Value;
	[SerializeField]public float Cool_Down;
	[SerializeField]public int Max_Stack;
	[SerializeField]public int Current_Stacks;
	[SerializeField]public int Item_ID;

}
