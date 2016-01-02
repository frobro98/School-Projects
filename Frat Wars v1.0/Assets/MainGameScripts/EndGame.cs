using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GlobalVars.iFeltaThiHealth <= 0.0f)
		{
			Application.LoadLevel("DeathScene");
		}
	}
}
