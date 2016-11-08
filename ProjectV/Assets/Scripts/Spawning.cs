using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Spawning : MonoBehaviour
{
	public static GameObject _Target;
	public GameObject  Mobs;
	public List<GameObject> EnemyType;
	public GameObject  MidBoss;
	public GameObject  BigBoss;
	public GameObject  LastBossMobs;
	public GameObject  LastBoss;
	public GameObject VinAura;
	public int MobAmount;
	public int LastMobAmount;
	public int MidBossAmount;
	public int BigBossAmount;
	public List<Vector3> SpawnPoint= new List<Vector3>();
	public GameObject[] SpawnPointPlacement;
	public GameObject[] MBSpawnPointPlacement;
	public List<Vector3> MBSpawnPoint= new List<Vector3>();

	// Use this for initialization
	void Start ()
	{
		EnemyType.Add(Resources.Load("Enemies/Mobs/Enemy")as  GameObject);
		EnemyType.Add(Resources.Load("Enemies/Mobs/Enemey-Wrath-Mob")as  GameObject);
 		_Target = GameObject.FindGameObjectWithTag ("Player");
		MobAmount = 0;
		MidBossAmount = 25;
		BigBossAmount = 7;

//		Mobs = GameObject.FindGameObjectWithTag("MobEnemy");
//
//		EnemyType = GameObject.FindGameObjectsWithTag("MobEnemy");

		SpawnPointPlacement =  GameObject.FindGameObjectsWithTag("Enemy_Spawn");

		MBSpawnPointPlacement =  GameObject.FindGameObjectsWithTag("MB_Enemy_Spawn");


		MidBoss = GameObject.FindGameObjectWithTag("MidBossEnemy");

		BigBoss= GameObject.FindGameObjectWithTag("BigBossEnemy");

		LastBoss =  GameObject.FindGameObjectWithTag("LastBossEnemy");

		if (SpawnPoint.Capacity == 0) {
			for (int x = 0; x < SpawnPointPlacement.Length; x++) {
				SpawnPoint.Add (SpawnPointPlacement [x].transform.position);
			}
		}
		if (MBSpawnPoint.Capacity == 0) {
			for (int x = 0; x < MBSpawnPointPlacement.Length; x++) {
				MBSpawnPoint.Add (MBSpawnPointPlacement [x].transform.position);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		_Target = GameObject.FindGameObjectWithTag ("Player");
		if (_Target == null) {
			_Target= GameObject.FindGameObjectWithTag("AirCraft");
		}



		if (MobAmount != 10) {
			Invoke  ("SpawnMobEnemy", 5f);
		}

//			if(MobAmount< 1){
//				InvokeRepeating("SpawnMidBossEnemy",5,10);
//			}



	}

	public void MobDown(){
		MobAmount--;
	}

	void SpawnMobEnemy(){
		int Spawnnum = Random.Range (0, SpawnPoint.Count);
		int Enemynum = Random.Range (0, EnemyType.Count);
		Instantiate (EnemyType[Enemynum] , SpawnPoint[Spawnnum], Quaternion.identity);
		MobAmount ++;
 		CancelInvoke ();
	}

	void SpawnMidBossEnemy(){
		 
		int MSnum = Random.Range (0,MBSpawnPoint.Capacity);
		Instantiate (MidBoss , MBSpawnPoint[MSnum], Quaternion.identity);
		CancelInvoke ();
	}

}

