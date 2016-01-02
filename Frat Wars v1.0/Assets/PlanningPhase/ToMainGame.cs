using UnityEngine;
using System.Collections;

public class ToMainGame : MonoBehaviour {

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
		GUI.Label (new Rect (300, 300, 200, 200), "Press ANY Key to Start!");
	}
}
