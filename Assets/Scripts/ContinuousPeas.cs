using UnityEngine;
using System.Collections;

public class ContinuousPeas : PeaSpawner {

	public float spawnInterval;
	protected float spawnTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {

		spawnTimer += Time.deltaTime;

		if (spawnTimer > spawnInterval) {
			SpawnPeas ();
			spawnTimer = 0;
		}
	}
}
