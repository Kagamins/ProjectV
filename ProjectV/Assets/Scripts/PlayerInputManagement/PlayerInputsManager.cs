using UnityEngine;
using System.Collections;
using ProjectV.ItemSystem;
public class PlayerInputsManager : MonoBehaviour {

	public static bool _EnterDangerZone=false;
	public Animator _Animator;
	public float _Forward;
	public float _Turn;
	public bool _Awakened;
	public float _LightAttack = 10f;
	public float _ChargeAttack = 15f;
	public Rigidbody _Rigidbody;
	bool _IsGrounded = true;
	bool _Jump = false;
	public float _EnemyDistance;
	public GameObject[] Enemies;
 	float _TurnAmount;
	float _ForwardAmount;
  	bool _Crouching;
	Transform _Position;
	float _Jump_Amount;
	public static bool _Rest=false;
	bool Flying = false;
 	//Combo Variables
//	float Heavy_Attack_;
//	float Light_Attack_;
	bool Awakened = false;
	//Weapon Related Variables
	bool _fire= false;
	bool w1;
	bool w2;
	bool w3;
	public GameObject x;
	bool _blade = false;
	bool _cannon = false;
	//GameObject of the Said Weapon
	public GameObject CannonShell;
	public GameObject _Wand,_Cannon,_Blade;
	bool _wand;
//	string x;
	bool _gauntlet;
	EQType Equipment_type;
//	public   GameObject _Bullet;
	public static Camera mcam;
	public static  Transform _target;
	public static ISWeaponDatabase WDB;
	public Transform Buster,CannonTip;
	void Start () {
		WDB = Resources.Load ("WeaponDB")as ISWeaponDatabase;

 		_Position = transform;
		_Animator = GetComponent<Animator> ();
		_Rigidbody = GetComponent<Rigidbody> ();
 		_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		_ForwardAmount =  5.5f;
		_TurnAmount =  250f;
		_Jump_Amount = 12;
//		Enemies = GameObject.FindGameObjectsWithTag ("MobEnemey");
  	}

	// Update is called once per frame
	void Update () {
		
		if (_target != null) {
			_EnemyDistance = Vector3.Distance (_target.position,_Position.position);
		}

//		Enemies = GameObject.FindGameObjectsWithTag ("MobEnemey");
//		Equipment_type =PlayerUIManager.Equiped_Weapon.Equipment_Slot;
		if (Input.GetButtonDown ("Pause_Toggle")) {
			if (!CameraManipulation.x) {
				CameraManipulation.z = true;
				CameraManipulation.pause = true;
			}if (CameraManipulation.x) {
				CameraManipulation.z = true;
			}
		}
		switch (Equipment_type) {
		case EQType.Axe:
 			break;
		case EQType.Blade:
			_LightAttack = 1f;
			_ChargeAttack = 50f;
			_blade = true;
			x = _Blade;
			if (_target != null) {
				if (Input.GetButtonDown ("Light")) {
					_Animator.SetTrigger ("Light");
					if (_LightAttack > _EnemyDistance) {
						_target.GetComponentInParent<Enemy> ().Hit (Random.Range (PlayerUIManager.Equiped_Weapon.Min_Damage, PlayerUIManager.Equiped_Weapon.Min_Damage + GameInformation.Aim * GameInformation.Strength));
					}
				} else {
					_Animator.ResetTrigger ("Light");
				}
				if (Input.GetButtonDown ("Heavy")) {
					_Animator.SetTrigger ("Heavy");
					if (_ChargeAttack > _EnemyDistance) {
						_target.GetComponentInParent<Enemy> ().Hit (Random.Range (PlayerUIManager.Equiped_Weapon.Min_Damage, PlayerUIManager.Equiped_Weapon.Min_Damage + GameInformation.Aim * GameInformation.Strength));
					}
				} else {
					_Animator.ResetTrigger ("Heavy");
				}
			}
			break;
		case EQType.Cannon:
			_cannon = true;
			x = _Cannon;
			if (Input.GetButtonDown ("Light")) {
				_Animator.SetTrigger ("Light");
				_fire = true;
				Firecannon ();
			} else {
				_Animator.ResetTrigger ("Light");
				_fire = false;

			}
   			break;
		case EQType.Wand:
			_wand = true;
			x = _Wand;
 			break;
		case EQType.Bullet:
 			break;
		case EQType.Bow:
 			break;
		case EQType.ChainBlade:
 			break;
		case EQType.Cannon_Spear:
 			break;
		case EQType.Cards:
 			break;
		case EQType.ChainBlade_Talisman:
 			break;
		case EQType.Claw:
 			break;
		case EQType.Dagger:
 			break;
		case EQType.Fan:
 			break;
 		case EQType.Arrow:
			break;
		default:
 			if (PlayerUIManager.Mana > 10) {
				if (_target != null) {
					if (Input.GetButtonDown ("Light")) {
						_Animator.SetTrigger ("Light");
						GameObject _Bullet = WDB.Get (3).Prefab;
  						Instantiate(_Bullet,Buster.position,Quaternion.identity);
						_Bullet.name = WDB.Get (3).Name;
						PlayerUIManager.Mana -= 10;
					} else {
						_Animator.ResetTrigger ("Light");
					}
				}
			}
 			break;
		}

		if (!Flying) {
			//Movement Commands Rotation
			if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0) {
				_Position.Rotate (0, Input.GetAxis ("Horizontal") * Time.deltaTime * _TurnAmount, 0);
				_Turn = Input.GetAxis ("Horizontal");
			}
			//Movement Commands Moving Forward and Backward  
			if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0) {
				_Position.Translate (Vector3.forward * Input.GetAxis ("Vertical") * Time.deltaTime * _ForwardAmount);
				_Forward = Input.GetAxis ("Vertical");
			}
		}
		//Jumping Command Going up

		if (PlayerUIManager.Stamina > 0) {
			if (Mathf.Abs (Input.GetAxis ("Jump")) > 0) {
				
				InvokeRepeating ("Jump",0.3f,3);	} 
			//Flying Command  
			if (Mathf.Abs (Input.GetAxis ("Ascend")) > 0) {
				Invoke ("Ascension",0.3f);
			}
		}
		//Flying Command Ascension 
//		if (Flying) {
//			if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0) {
//				_Position.Rotate (0, Input.GetAxis ("Horizontal") * Time.deltaTime * _TurnAmount, 0);
//				_Turn = Input.GetAxis ("Horizontal");
//			}
//			//Movement Commands Moving Forward and Backward  
//			if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0) {
//				_Position.Translate (Vector3.forward * Input.GetAxis ("Vertical") * Time.maximumDeltaTime *0.65f);
//				_Forward = Input.GetAxis ("Vertical");
//			}
//
//			if (Mathf.Abs (Input.GetAxis ("Jump")) > 0) {
//				_Position.Translate (Vector3.up*Input.GetAxis("Jump")*Time.maximumDeltaTime*_Jump_Amount*0.3f);
// 			}
//		 
//			//Descending Command Going Down
//			if (Mathf.Abs (Input.GetAxis ("Descend")) > 0) {
//				_Position.Translate(Vector3.down*_Jump_Amount*Time.maximumDeltaTime*0.3f);
//
//			}
//
//		} 
		//Targeting system


      //Combo Variables
	

//			if (Input.GetButtonDown ("Heavy")) {
//				_Animator.SetTrigger ("Heavy");
//				if (_EnemyDistance > _LightAttack) {
//					_target.GetComponentInParent<Enemy> ().Hit (Random.Range (PlayerUIManager.Equiped_Weapon.Min_Damage, PlayerUIManager.Equiped_Weapon.Min_Damage + GameInformation.Aim * GameInformation.Strength + GameInformation.Intellect));
//				}
//			} else {
//				_Animator.ResetTrigger ("Heavy");
//			}
 		//Resting 
		if (_Rest) {
			Invoke ("Regeneration", 0.5f);
		}

	 //Weapon Switching Schematic as Well as Instantiating the weapon
			if (Input.GetButtonDown ("Weapon_Switch_R")) {
			if (!w1) {
				_blade = false;
				_wand = false;
				_cannon = false;
				x.SetActive (false);
				PlayerUIManager.Equiped_Weapon = PlayerUIManager.weapon1;
//				x= Instantiate (PauseMenu.WDB.Get (PlayerUIManager.Equiped_Weapon.ItemID).Prefab,_Blade.transform.position,_Blade.transform.rotation) as GameObject;
				Weapon myWeapon =  	x.AddComponent<Weapon>();
 				myWeapon.ItemID = PlayerUIManager.Equiped_Weapon.ItemID;
				myWeapon.Name = PlayerUIManager.Equiped_Weapon.Name;
				myWeapon.Burden = PlayerUIManager.Equiped_Weapon.Burden;
				myWeapon.Equipment_Slot = PlayerUIManager.Equiped_Weapon.Equipment_Slot;
				myWeapon.Min_Damage = PlayerUIManager.Equiped_Weapon.Min_Damage;
				myWeapon.Durability = PlayerUIManager.Equiped_Weapon.Durability;
				myWeapon.Max_Durability = PlayerUIManager.Equiped_Weapon.Max_Durability;
				myWeapon.Value = PlayerUIManager.Equiped_Weapon.Value;
				myWeapon.Equipment_Element = PlayerUIManager.Equiped_Weapon.Equipment_Element;
				myWeapon.Equipment_Type = PlayerUIManager.Equiped_Weapon.Equipment_Type;
				myWeapon.Equipment_Range = PlayerUIManager.Equiped_Weapon.Equipment_Range;
				Equipment_type = PlayerUIManager.Equiped_Weapon.Equipment_Type;
				PlayerUIManager.Equipment_Slot = PlayerUIManager.Equiped_Weapon.Equipment_Slot;
				x.SetActive (true);
 				x.tag = "Weapon";
//				x.transform.position = new Vector3 (_Blade.transform.position.x,_Blade.transform.position.y,_Blade.transform.position.z); 
   				Debug.Log ("R_Wep_");
				w1 = true;
				w2 = false;
				w3 = false;
			}  
			}
//		x.transform.position = new Vector3 (_Blade.transform.position.x,_Blade.transform.position.y,_Blade.transform.position.z); 
//		x.transform.rotation = _Blade.transform.rotation;
		if(Input.GetButtonDown("Weapon_Switch_M")){
 			x.SetActive (false);
			_blade = false;
			_wand = false;
			_cannon = false;
 			Equipment_type = EQType.None;
			PlayerUIManager.Equiped_Weapon = PlayerUIManager.weapon3;
 		}
			if (Input.GetButtonDown ("Weapon_Switch_L")) {
				if (!w2) {
				x.SetActive (false);
				_blade = false;
				_wand = false;
				_cannon = false;
				PlayerUIManager.Equiped_Weapon = PlayerUIManager.weapon2;

//				x = Instantiate (PauseMenu.WDB.Get (PlayerUIManager.Equiped_Weapon.ItemID).Prefab,_Blade.transform.position,_Blade.transform.rotation) as GameObject;
				Weapon myWeapon = x.AddComponent<Weapon>();
 				myWeapon.ItemID = PlayerUIManager.Equiped_Weapon.ItemID;
				myWeapon.Name = PlayerUIManager.Equiped_Weapon.Name ;
				myWeapon.Burden =  PlayerUIManager.Equiped_Weapon.Burden;
				myWeapon.Equipment_Slot = PlayerUIManager.Equiped_Weapon.Equipment_Slot ;
				myWeapon.Min_Damage = PlayerUIManager.Equiped_Weapon.Min_Damage ;
				myWeapon.Durability = PlayerUIManager.Equiped_Weapon.Durability ;
				myWeapon.Max_Durability = PlayerUIManager.Equiped_Weapon.Max_Durability ;
				myWeapon.Value = PlayerUIManager.Equiped_Weapon.Value ;
				myWeapon.Equipment_Element = PlayerUIManager.Equiped_Weapon.Equipment_Element ;
				myWeapon.Equipment_Type =PlayerUIManager.Equiped_Weapon.Equipment_Type;
				myWeapon.Equipment_Range = PlayerUIManager.Equiped_Weapon.Equipment_Range;
 				PlayerUIManager.Equipment_Slot = PlayerUIManager.Equiped_Weapon.Equipment_Slot;
				PlayerUIManager.WeaponTypes = PlayerUIManager.Equiped_Weapon.Equipment_Type;
				x.SetActive (true);
				x.tag = "Weapon";
  					Debug.Log ("L_Wep_");
					w1 = false;
					w3 = false;
					w2 = true;
				} 
			}
		 
			 

	 

			
		 

		//-------------Animator Variables----------//
		//Movement Variables
		_Animator.SetFloat("Move", Input.GetAxis("Vertical"));
		_Animator.SetFloat("Turn", Input.GetAxis("Horizontal") );
		_Animator.SetFloat ("Jump",Input.GetAxis("Jump"));
		_Animator.SetBool ("Flying",Flying);
		_Animator.SetBool ("OnGround",_IsGrounded);
		_Animator.SetBool ("Awakened",_Awakened);
		_Animator.SetBool ("Blade", _blade);
		_Animator.SetBool ("Wand",_wand);
		_Animator.SetBool("Fire",_fire);
		_Animator.SetBool("Cannon",_cannon);

	 

		 
}
	void Regeneration(){
 
		if (PlayerUIManager.Stamina != PlayerUIManager.MaxStamina) {
			PlayerUIManager.Stamina++;
		}
		if (PlayerUIManager.Health != PlayerUIManager.maxHealth) {
			PlayerUIManager.Health++;
		}
		if (PlayerUIManager.Mana != PlayerUIManager.MaxMana) {
			PlayerUIManager.Mana++;
		}
		CancelInvoke ();

	}
	public void Firecannon(){
		int Recoil = 15;
		Instantiate (CannonShell, CannonTip.position, Quaternion.identity);
		_Position.Translate (Vector3.back * Recoil*Time.deltaTime);
 
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "AirCraft") {
			PlayerUIManager.Mount = true;
			if(Input.GetButtonDown("Mount")){
				CameraManipulation.x = true;
			}
		} else {
			PlayerUIManager.Mount = false;
		
		}
		if (other.gameObject.tag == "Ground") {
			_IsGrounded = true;
			Flying = false;
 		}  

		if (other.gameObject.tag == "School") {
			_Rest = true;
		} else {
			_Rest = false;
		}

		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<Enemy>().Hit(Random.Range(10, 40+ 12*GameInformation.Aim+12* GameInformation.Dexetry));
		}
		if(other.gameObject.tag=="DangerZone"){
			_EnterDangerZone = true;
			
		}
		if (other.gameObject.tag == "SafeZone") {
			_EnterDangerZone = false;
		}
	}
	void Damage(Collision x){

		OnCollisionEnter (x);
		CancelInvoke ();
	}

	void Jump(){
		//Jumping 
		if (_IsGrounded) {
 
			_Position.Translate (Vector3.up *_Jump_Amount*Time.maximumDeltaTime);
 			_IsGrounded = false;
			PlayerUIManager.Stamina--; 

		}
			CancelInvoke ();
	}
	//Floating Script if after jumping you press the Flying Toggles
	void Ascension(){
		if (PlayerUIManager.Mana > 0) {
			Flying = true;
			_Position.Translate (Vector3.up*Time.maximumDeltaTime*0.45f);
 			PlayerUIManager.Mana--;
 		} 
		 
	
		 
		CancelInvoke ();
	  
}
}