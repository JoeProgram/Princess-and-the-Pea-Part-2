using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public GameObject winScreen;
	public GameObject loseScreen;
	public GameObject cantReachScreen;

	// Update is called once per frame
	void Update () {
	
		// restart on R
		if( Input.GetKeyDown(KeyCode.R) ) Application.LoadLevel( Application.loadedLevel );

	}

	public void ShowWinScreen(){
		StartCoroutine (WinHelper ());
	}

	protected IEnumerator WinHelper(){
		winScreen.SetActive (true);
		yield return new WaitForSeconds(4);
		Application.LoadLevel( (Application.loadedLevel + 1) % Application.levelCount );
	}

	public void ShowLoseScreen(){
		StartCoroutine (LoseHelper ());
	}

	protected IEnumerator LoseHelper(){
		loseScreen.SetActive (true);
		yield return new WaitForSeconds(4);
		Application.LoadLevel( Application.loadedLevel );
	}

	public void ShowCantReachScreen(){
		StartCoroutine (CantReachHelper ());
	}
	
	protected IEnumerator CantReachHelper(){
		cantReachScreen.SetActive (true);
		yield return new WaitForSeconds(4);
		Application.LoadLevel( Application.loadedLevel );
	}


}
