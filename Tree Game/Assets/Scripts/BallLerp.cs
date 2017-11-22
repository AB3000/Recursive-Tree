using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLerp : MonoBehaviour {

	public NodeScript head;
	//public Transform startMarker;
	public Transform endMarker;
	public float speed = 1F;
	private float startTime;
	private float journeyLength;
	private float distCovered;



	//private float direction;
	Vector3 dire;
	//int count;
	void Start() {
		startTime = Time.time;
		//startMarker = this.transform;
		//endMarker = new Transform();
		endMarker.position = head.transform.position;
		journeyLength = Vector3.Distance(transform.position, endMarker.position);

	}
	void Update() {
		

		distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		//transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
		//startMarker.position = transform.position;
		transform.position = Vector3.Lerp(transform.position, endMarker.position, fracJourney);

		endMarker.position = head.transform.position;

		if (head.rightChild == null) {
			Debug.Log ("You are at the end!");
			return;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			/*startTime = Time.time;
			distCovered = 0;
			head = head.leftChild;*/
			GoLeft ();
			//Debug.Log ("This is the head position " + head.transform.position);
			//endMarker.position = head.transform.position;

		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			/*startTime = Time.time;
			distCovered = 0;
			head = head.rightChild;*/
			GoRight ();
			//endMarker = posit
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			GoBack ();
			Debug.Log ("Head is now " + head + "with position" + head.transform.position);

		}

		//Debug.Log ("The position of the head " + head.transform.position);

		//endMarker.position = head.transform.position;


	}


	bool GoLeft(){
		startTime = Time.time;
		distCovered = 0;
		if (head.leftChild == null)
			return false;
		else {
			head = head.leftChild;
			return true;
		}


	}

	bool GoRight(){
		startTime = Time.time;
		distCovered = 0;
		if (head.rightChild == null)
			return false;
		else {
			head = head.rightChild;
			return true;
		}
		//head = head.rightChild;

	}

	bool GoBack(){
		startTime = Time.time;
		distCovered = 0;
		if (head.head == null)
			return false;
		else {
			Debug.Log ("head pos: " + head.head.transform.position);
			head = head.head;
			return true;
		}
		//head = head.head;
	}
	/*void OnGUI(){
		GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "dsadsadsa");
	}*/
}
