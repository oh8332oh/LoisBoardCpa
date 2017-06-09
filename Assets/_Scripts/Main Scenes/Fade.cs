using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//의미없는 스크립트 씬의 변화가 있을때 바로 안봐끼고 천천히 사라졌다가 천천히 나타나게하려했음 
public class Fade : MonoBehaviour {
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;
	// Use this for initialization
	void OnGuI(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	public float BeginFade(int direction){
		fadeDir = direction;
		return(fadeSpeed);
	}
	void OnLevelWasLoaded(){
		BeginFade(-1);
	}
}
