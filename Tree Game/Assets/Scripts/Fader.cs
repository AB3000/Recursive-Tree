using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

	public Texture2D fadeOutTexture; //texture over the scene
	public float fadeSpeed = 0.8f; //fade speed

	private int drawDepth = -1000; //order in game
	private float alpha = 1.0f; 
	private int fadeDir = -1; //fade in = 1, fade out = -1
	// Use this for initialization


	void OnGUI(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);
		GUI.color = new Color (GUI.color.r,GUI.color.g,GUI.color.b ); 
		GUI.depth = drawDepth; //black goes on top
		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height) ,fadeOutTexture); //fits entire screen
	}

	public float BeginFade(int direction){
		fadeDir = direction;
		return (fadeSpeed); 
	}

	void OnLevelWasLoaded(){
		alpha = 1;
		BeginFade (-1); 
	}
}
