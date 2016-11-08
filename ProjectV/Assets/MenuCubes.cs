using UnityEngine;
using System.Collections;

public class MenuCubes : MonoBehaviour {
	public GameObject Cubes;
	public static Transform cube_pos;
	int x;
	bool z = false;
	// Use this for initialization
	void Start () {
		
		cube_pos = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		if (!z) {
//			for (int cnt = 0; cnt < 2; cnt++) {
//				Instantiate (Cubes, this.gameObject.transform.position, this.gameObject.transform.rotation);
//				Cubes.AddComponent<MenuCubes>();
//			}
//		}
//		z = true;
		transform.Rotate (Time.deltaTime*20, 0, Time.deltaTime*3);

	}
}
