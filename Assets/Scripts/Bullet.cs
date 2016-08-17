using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	float speed;
	// Use this for initialization
	void Start () {
		speed = 15f;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * speed;
	}
	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "MobEnemy") {
			other.gameObject.GetComponent<Enemy>().Hit(Random.Range(10, 40+ 12*GameInformation.Aim* GameInformation.Dexetry));

		}


	}
}
