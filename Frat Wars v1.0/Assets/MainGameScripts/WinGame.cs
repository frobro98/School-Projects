using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GlobalVars.enemyFratHealth <= 0.0f)
		{
			Application.LoadLevel("WinScene");
		}
	}
}
