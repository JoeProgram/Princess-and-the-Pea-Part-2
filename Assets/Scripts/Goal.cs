using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public Transform standingPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){

		if (collider.CompareTag ("jump_zone")) {
			collider.transform.parent.GetComponent<Princess>().JumpToGoal( standingPoint );
		}

	}
}
