using UnityEngine;
using System.Collections;
public class BasicExpertiseSetup : MonoBehaviour {
	public int Max_Expertise_Points = 1500;
	public int Current_Expertise_Points = 0;
	//Magic Expertises
	public int Magic_Offense;
	public int Magic_Support;
	public int Magic_Deffence;
	public int Magic_Debuff;
	//Physical Expertises
	public int Melee_Offence;
	public int Melee_Defence;
	public int Survival_instinct;
	public int Ranged_Offence;
	public int Ranged_Support;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if (AlphaMenu.HaveLoaded) {
			Magic_Offense = GameInformation.Magic_Offense;
			Magic_Deffence = GameInformation.Magic_Deffence;
			Magic_Debuff = GameInformation.Magic_Debuff;
			Magic_Support = GameInformation.Magic_Support;
			Melee_Defence = GameInformation.Melee_Defence;
			Melee_Offence = GameInformation.Melee_Offence;
			Survival_instinct = GameInformation.Survival_instinct;
			Ranged_Offence = GameInformation.Ranged_Offence;
			Ranged_Support = GameInformation.Ranged_Support;
		}

	
	}
}
