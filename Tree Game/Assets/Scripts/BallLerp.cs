﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLerp : MonoBehaviour
{

    public NodeScript head;
    //public Transform startMarker;
    public Transform endMarker;
    public float speed = 1F;
    private float startTime;
    private float journeyLength;
    private float distCovered;

    public Image recurseL;
    public Image recurseR;

    //private float direction;
    Vector3 dire;
    //int count;
    void Start()
    {
        startTime = Time.time;
        //startMarker = this.transform;
        //endMarker = new Transform();
        endMarker.position = head.transform.position;
        journeyLength = Vector3.Distance(transform.position, endMarker.position);

    }
    void Update()
    {


        distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        //transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        //startMarker.position = transform.position;
        transform.position = Vector3.Lerp(transform.position, endMarker.position, fracJourney);

        endMarker.position = head.transform.position;

        if (head.rightChild == null)
        {
            Debug.Log("You are at the end!");
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            /*startTime = Time.time;
			distCovered = 0;
			head = head.leftChild;*/
            GoLeft();
            //Debug.Log ("This is the head position " + head.transform.position);
            //endMarker.position = head.transform.position;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            /*startTime = Time.time;
			distCovered = 0;
			head = head.rightChild;*/
            GoRight();
            //endMarker = posit
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GoBack();
            Debug.Log("Head is now " + head + "with position" + head.transform.position);

        }

        //Debug.Log ("The position of the head " + head.transform.position);

        //endMarker.position = head.transform.position;


    }


    public bool GoLeft()
    {
        recurseL.color = Color.yellow;
        recurseR.color = Color.white;

        startTime = Time.time;
        distCovered = 0;
        if (head.leftChild == null)
            return false;
        else
        {
            head = head.leftChild;
            return true;
        }


    }

    public bool GoRight()
    {
        recurseL.color = Color.white;
        recurseR.color = Color.yellow;

        startTime = Time.time;
        distCovered = 0;
        if (head.rightChild == null)
            return false;
        else
        {
            head = head.rightChild;
            return true;
        }
        //head = head.rightChild;

    }

    public bool GoBack()
    {
        startTime = Time.time;
        distCovered = 0;
        if (head.head == null)
            return false;
        else
        {
            Debug.Log("head pos: " + head.head.transform.position);
            head = head.head;
            return true;
        }
        //head = head.head;
    }
    /*void OnGUI(){
		GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "dsadsadsa");
	}*/
}
