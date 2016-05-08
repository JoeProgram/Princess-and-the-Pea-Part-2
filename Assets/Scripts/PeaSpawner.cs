using UnityEngine;
using System.Collections;

public class PeaSpawner : MonoBehaviour {

	public GameObject peaPrefab;

	public int peasToSpawn;

	// Use this for initialization
	protected virtual void Start () {

		SpawnPeas ();

	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

	protected virtual void SpawnPeas(){
		for (int i = 0; i < peasToSpawn; i++) {
			Vector3 peaPosition = new Vector3( Random.Range(GetComponent<Collider>().bounds.min.x,GetComponent<Collider>().bounds.max.x), Random.Range(GetComponent<Collider>().bounds.min.y,GetComponent<Collider>().bounds.max.y), Random.Range(GetComponent<Collider>().bounds.min.z,GetComponent<Collider>().bounds.max.z));
			Instantiate( peaPrefab, peaPosition, Quaternion.identity);
		}
	}
}
