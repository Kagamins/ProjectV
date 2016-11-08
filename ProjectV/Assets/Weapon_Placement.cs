using UnityEngine;
using System.Collections;

public class Weapon_Placement : MonoBehaviour {
	public GameObject _Hilt;
	Transform _position;
	void Start () {
		_position = transform;
	}
	
	// Update is called once per frame
	void Update () {
		_position.position = _Hilt.transform.position;
		_position.rotation = _Hilt.transform.rotation;
	
	}
}
