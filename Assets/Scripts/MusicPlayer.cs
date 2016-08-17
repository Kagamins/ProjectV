using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	public AudioClip[]Clips;
	public AudioSource _As;
 	void Start () {
		_As = FindObjectOfType<AudioSource> ();
		_As.loop = false;
	}
	
 	void Update () {
		if (!_As.isPlaying) {
			_As.clip = GetRandomClip ();
			_As.Play();
		}
	}
	  AudioClip GetRandomClip() {
		return Clips[Random.Range(0,Clips.Length)];
 	}
}
