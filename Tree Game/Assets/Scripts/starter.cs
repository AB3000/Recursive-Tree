using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starter : MonoBehaviour {

	public string scene;
	//WORKS
	public void ChangeScenes(string scene){
		Application.LoadLevel (scene);

		//float fadeTime = GameObject.Find ("treasurechest").GetComponent<Fader> ().BeginFade (1);

	}

	/*IEnumerator ChangeScenes(){
		float fadeTime = GameObject.Find ("treasurechest").GetComponent<Fader> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (scene);
		
	}*/




	// Use this for initialization

}
