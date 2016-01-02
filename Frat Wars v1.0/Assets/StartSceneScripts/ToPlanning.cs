using UnityEngine;
using System.Collections;

public class ToPlanning : MonoBehaviour {

	public Texture startScreen;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.anyKey)
		{
			Application.LoadLevel("MainGame");
		}
	}
	void OnGUI()
	{
		GUI.Label (new Rect (300, 150, 200, 200), "Press ANY Key to start!");
		GUI.DrawTexture ( new Rect (0,0,Screen.width,Screen.height),startScreen);
	}
}
