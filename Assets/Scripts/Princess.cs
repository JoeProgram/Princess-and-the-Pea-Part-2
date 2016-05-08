using UnityEngine;
using System.Collections;

public class Princess : MonoBehaviour {

	public Collider jumpZone;
	public float jumpZoneBuffer;
	public float jumpTime;

	protected Mattress startingMattress = null;
	protected bool reachedGoal = false;

	protected bool hasEnded = false;

	public float cantReachTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){



		if( collision.gameObject.CompareTag("mattress") && startingMattress == null){
			startingMattress = collision.gameObject.GetComponent<Mattress>();

			jumpZone.transform.localScale = new Vector3( startingMattress.transform.localScale.x + jumpZoneBuffer, jumpZone.transform.localScale.y, startingMattress.transform.localScale.z + jumpZoneBuffer);

		}else if(collision.gameObject.CompareTag("deadly") && !hasEnded){

			GameObject.Find("Level").GetComponent<Level>().ShowLoseScreen();
			hasEnded = true;
		}

	}

	void OnTriggerEnter( Collider collider ){

		if (collider.CompareTag ("cant_reach_zone")) {
			StartCoroutine("CantReach");
		}

	}

	public void JumpToGoal( Transform standingPoint ){


		if (!reachedGoal && !hasEnded) {
			reachedGoal = true;
			hasEnded = true;
			StartCoroutine (JumpToGoalHelper (standingPoint));
		}
	}

	public IEnumerator JumpToGoalHelper(Transform standingPoint){
	
		GetComponent<Rigidbody>().isKinematic = true;
		iTween.MoveTo (gameObject, standingPoint.position, 2);
		iTween.RotateTo (gameObject, Vector3.forward, 2); 
		yield return new WaitForSeconds(2);
		GameObject.Find("Level").GetComponent<Level>().ShowWinScreen();
		
	}

	public IEnumerator CantReach(){
		yield return new WaitForSeconds( cantReachTime );

		if (!hasEnded) {

			hasEnded = true;
			GameObject.Find("Level").GetComponent<Level>().ShowCantReachScreen();

		}
	}
}
