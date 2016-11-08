using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Targeting : MonoBehaviour {
	public   List<Transform> Enemies = new List<Transform>();
	public   Transform _transform;
	public   Transform _Target;
//	public Transform[] Targets;
	 
	void Start () {
		_Target = null;
		_transform = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	

	public   void AddAllEnemies (){
		GameObject[] go = GameObject.FindGameObjectsWithTag ("MobEnemy");
		foreach ( GameObject enemy in go) {
			AddTarget (enemy.transform);

		}
	}

	public   void AddTarget(Transform enemy){
		Enemies.Add (enemy);

	}

	public   void SortTargetbyDistance(){
		Enemies.Sort(delegate(Transform t1,Transform t2){
			return Vector3.Distance(t1.position,_transform.position).CompareTo(Vector3.Distance(t2.position,_transform.position));	
		});
	}

	public   void TargetEnemy(){
		if (_Target == null) {
//						SortTargetbyDistance ();
			_Target = Enemies [0];
		} else {
			int index = Enemies.IndexOf(_Target);
			if (index < Enemies.Capacity - 1) {
				index++;
			} else {
				index = 0;
			}

			DeselectTarget ();
			_Target = Enemies [index];
		}
		SelectTarget ();
	}

	public    void SelectTarget(){
		PlayerInputsManager._target = _Target;

	}

	public   void DeselectTarget(){
		_Target = null;
	}
	void Update () {
		if (_transform = null) {
			_transform = GameObject.FindGameObjectWithTag ("Player").transform;
		}
		AddAllEnemies ();
		if (Input.GetKeyDown (KeyCode.Tab)) {
						TargetEnemy ();
					}
	
	}
}
