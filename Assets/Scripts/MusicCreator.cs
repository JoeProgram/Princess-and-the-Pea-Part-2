using UnityEngine;
using System.Collections;

public class MusicCreator : MonoBehaviour {

	public GameObject musicPrefab;

	// Use this for initialization
	void Start () {
	
		if (GameObject.Find ("Music") == null) {

			GameObject music = Instantiate(musicPrefab) as GameObject;
			music.name = "Music";
			DontDestroyOnLoad( music );

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
