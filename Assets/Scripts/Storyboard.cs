using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Storyboard : MonoBehaviour {

	public List<SpriteRenderer> boards;
	protected int boardIndex = 0;

	// Use this for initialization
	void Start () {
		boards = new List<SpriteRenderer>();

		foreach (Transform child in transform) {
			boards.Add( child.GetComponent<SpriteRenderer>());
		}

		boards [0].enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1)) {

			if( boardIndex + 1< boards.Count ){

				boards[boardIndex].enabled = false;
				boardIndex ++;
				boards[boardIndex].enabled = true;

			} else {
				Application.LoadLevel( (Application.loadedLevel + 1) % Application.levelCount );
			}

		}

	}


}
