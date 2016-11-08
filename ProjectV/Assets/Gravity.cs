using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public GameObject _player;
	public GameObject _Earth;
	public float Distance;
	public Vector3 Velocity= new Vector3(3,5,5);

	void Start () {
//		_player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance(_Earth.transform.position,_player.transform.position);
		if (20f>=Distance&Distance > 5f) {
			_player.transform.Translate (Vector3.MoveTowards(_player.transform.position,_Earth.transform.position,5f)*Time.deltaTime );
		}
		if (Distance < -5f) {
			_player.transform.Translate (Vector3.up*Time.deltaTime );
		}
 	}
}
