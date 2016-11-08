using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class Enemy : MonoBehaviour
{
	private bool AddedExp = false;
	public   int health,maxhealth;
	private Image HealthBar;
//	public int Health{get{return health;}}
	public GameObject CBTPrefab;
	//Enemy Targeting System Variables 
	private Renderer _Renderer;
	public Transform Target;
	public float _LookTarget;
	public float _attackTarget;
	public float _Targeting_Distance;
	public float _Enemy_Speed;
	public float Damp;
	public Rigidbody _RigidBody;
	//Patroling System Variables
	public Vector3 PatrolPath1,PatrolPath2,PatrolPath3;
	public GameObject[] PathPlacement;
	public float Path_Away_Distance_1,Path_Away_Distance_2,Path_Away_Distance_3;

//	private int KOCounter;
	//public GameObject KoCounterTxt;
	// Use this for initialization
	void Start ()
	{
		_Enemy_Speed = 10f;
		_LookTarget = 50f;
		_attackTarget = 20f;
 		_Renderer = this.gameObject.GetComponentInChildren<Renderer> ();
		_RigidBody = GetComponent<Rigidbody> ();
//		Target = GameObject.FindGameObjectWithTag("Player").transform;
		AddedExp = false;
		health = 100+maxhealth;
		maxhealth = 100;
//		HealthBar = transform.FindChild("EnemyCanvas").FindChild("HealthBG").FindChild("HealthFG").GetComponent<Image>();
		PathPlacement = GameObject.FindGameObjectsWithTag ("Mob_Waypoint");
		Target = GameObject.FindGameObjectWithTag ("Player").transform;

		 
		PatrolPath1 = PathPlacement[0].transform.position;
		PatrolPath2 = PathPlacement[1].transform.position;
		PatrolPath3 = PathPlacement[2].transform.position;

	}
	
	// Update is called once per frame
	void Update ()
	{
 //		HealthBar.fillAmount = (float)health / (float)maxhealth;
		if (Target == null) {
			Target = GameObject.FindGameObjectWithTag ("Player").transform;
		}else{
 			Target = GameObject.FindGameObjectWithTag ("AirCraft").transform; 
		}
		bool x = false;
		if (LevelUp.HaveLeveled) {
			x = false;
		}
		if (!x) {
			if (GameInformation.PlayerLevel < 1) {

				maxhealth += GameInformation.PlayerLevel * maxhealth;
				x = true;
			}
			LevelUp.HaveLeveled = false;
		}
		if (health <= 0) {
			Destruction();
		}
		Target = Spawning._Target.transform;
 			 
		 

	}
	void FixedUpdate(){

		_Targeting_Distance = Vector3.Distance (Target.transform.position,transform.position);
		Path_Away_Distance_1= Vector3.Distance (transform.position, PatrolPath1);
		Path_Away_Distance_2= Vector3.Distance (transform.position, PatrolPath2);
		Path_Away_Distance_3= Vector3.Distance (transform.position, PatrolPath3);
//		FillAmount ();
		 
		if (_Targeting_Distance < _LookTarget) {
			_Renderer.material.color = Color.yellow;
			LookAtTarget ();
		} else {
			_Renderer.material.color = Color.clear;

			if(Path_Away_Distance_1<_Targeting_Distance ){
				PathwayPatroling (PatrolPath1);
			}

			if(Path_Away_Distance_2<_Targeting_Distance ){
				PathwayPatroling (PatrolPath2);
			}

			if(Path_Away_Distance_3<_Targeting_Distance) {
				PathwayPatroling (PatrolPath3);
			}

		}



		if (_Targeting_Distance < _attackTarget) {
			LookAtTarget ();
 			Attack ();
			_Renderer.material.color = Color.red;
		}  
	}

	void LookAtTarget(){
		Quaternion rotation = Quaternion.LookRotation (Target.position - transform.position); 
		transform.rotation = Quaternion.Slerp (transform.rotation,rotation,Time.deltaTime*Damp);
	}
	void PathwayPatroling(Vector3 x){
		Quaternion rotation = Quaternion.LookRotation (x - transform.position); 
		transform.rotation = Quaternion.Slerp (transform.rotation,rotation,Time.deltaTime*Damp);
		transform.Translate (Vector3.MoveTowards(transform.position,Target.position,0.2f)*Time.deltaTime*_Enemy_Speed);
		CancelInvoke ();

	}
	void Attack(){
		transform.Translate (Vector3.forward*_Enemy_Speed*Time.deltaTime*0.2f);
	}

	 public void KoCountUp(){
 		GameInformation.BodyCount ++;
 				}
	 

	 void Destruction (){
 		AddExperience.AddExp ();
 		DestroyObject(gameObject);
		KoCountUp ();
		Instantiate (PauseMenu.WDB.Get(Random.Range(0,PauseMenu.WDB.Count)).Prefab,transform.position,transform.rotation);
		PlayerInputsManager._target = null;
 	}
	void OnMouseEnter(){
		PlayerInputsManager._target = this.gameObject.transform;
	}
	 public void Hit(int damage){
		health -= damage;
//		HealthBar.fillAmount = (float)health / (float)maxhealth;
//		InitCBT (health.ToString());
	}

	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponentInChildren<PlayerUIManager> ().PHit (Random.Range (10, 20));
			
		}
		if (other.gameObject.tag == "Weapon") {
			Hit(Random.Range(other.gameObject.GetComponent<Weapon>().Min_Damage,other.gameObject.GetComponent<Weapon>().Min_Damage + GameInformation.Aim*GameInformation.Strength));
		}
	}
	void FillAmount(){
		HealthBar.fillAmount = (float)health / (float)maxhealth;
	}
	void InitCBT(string DmG){
		Instantiate (CBTPrefab);
		//RectTransform tempRect = temp.GetComponent<RectTransform>();
		CBTPrefab.transform.SetParent(transform.FindChild("EnemyCanvas"));
		CBTPrefab.transform.localScale = CBTPrefab.transform.localScale;
		CBTPrefab.transform.localRotation = CBTPrefab.transform.localRotation;
		CBTPrefab.GetComponent<Text> ().text = DmG;


	}
}

