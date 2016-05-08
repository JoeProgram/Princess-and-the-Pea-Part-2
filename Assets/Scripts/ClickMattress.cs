using UnityEngine;
using System.Collections;

public class ClickMattress : MonoBehaviour {
	

	public float rotateSpeed;

	public Material flashMaterial;
	public float flashTime;

	public LayerMask mattressMask;

	public float minStrength;
	public float maxStrength;
	public float chargeTime;
	protected float pullStrength;
	protected float pushStrength;

	public ParticleSystem featherPrefab;

	protected Princess princess;

	// Use this for initialization
	void Start () {
	
		princess = GameObject.Find ("Princess").GetComponent<Princess>();
		pullStrength = minStrength;
		pushStrength = minStrength;


	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 newPosition = new Vector3 (princess.transform.position.x, transform.parent.position.y, princess.transform.position.z);
		transform.parent.position = Vector3.Lerp (transform.parent.position, newPosition, 0.025f);



		if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) ) {

			RaycastHit hitInfo;
			Ray clickRay = Camera.main.ScreenPointToRay( Input.mousePosition );

			if( Physics.Raycast( clickRay, out hitInfo, Mathf.Infinity, mattressMask.value ) ){
				if( hitInfo.collider.CompareTag("mattress")){
			
					if( Input.GetMouseButtonUp(0)) Push( hitInfo.collider.GetComponent<Rigidbody>(), hitInfo.point, clickRay);
					else Pull( hitInfo.collider.GetComponent<Rigidbody>(), hitInfo.point, clickRay);

					StartCoroutine( Flash( hitInfo.collider.GetComponent<Renderer>()));
				}
			}
		}

		
		// charge up push strength
		if (Input.GetMouseButton (0)) {
			pushStrength = Mathf.Min( maxStrength, pushStrength + maxStrength / chargeTime * Time.deltaTime );
		} else {
			pushStrength = minStrength;
		}
		
		// charge up push strength
		if (Input.GetMouseButton (1)) {
			pullStrength = Mathf.Min( maxStrength, pullStrength + maxStrength / chargeTime * Time.deltaTime );
		} else {
			pullStrength = minStrength;
		}

		// move the camera
		if (Input.GetAxis("Horizontal") != 0) {
			transform.parent.Rotate( new Vector3(0,Input.GetAxis("Horizontal"),0) * -rotateSpeed);
		}
	}

	void Push( Rigidbody mattress, Vector3 point, Ray clickRay ){
		Vector3 push = new Vector3( clickRay.direction.x, 0, clickRay.direction.z).normalized * pushStrength;
		mattress.AddForceAtPosition( push, point );
		pushStrength = minStrength;
		Instantiate (featherPrefab, point, Quaternion.identity);
	}

	void Pull( Rigidbody mattress, Vector3 point, Ray clickRay ){
		Vector3 pull = new Vector3( clickRay.direction.x, 0, clickRay.direction.z).normalized * -pullStrength;
		mattress.AddForceAtPosition( pull, point );
		pullStrength = minStrength;
		Instantiate (featherPrefab, point, Quaternion.identity);
	}

	IEnumerator Flash( Renderer r ){
		iTween.ColorFrom (r.gameObject, Color.blue, 0.25f);
		yield return null;
	}




}
