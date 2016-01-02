using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public Texture pauseScreen;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			GlobalVars.resourcePoint += 1000;
		}

		if (Input.GetKeyDown(KeyCode.P) && StartUp.isStart == false)
		{
			if (Time.timeScale == 0.0f) 
			{
				Time.timeScale = 1.0f;
			}
			else 
			{
				Time.timeScale = 0.0f;
			}
		}
	}
	void OnGUI()
	{

		//GUI.Label (new Rect (0, 0, 200, 200), "Pledges: " + force.ToString());
		//GUI.Label (new Rect (0, 20, 200, 200), "Enemy Frat: " + EnemyCount.ToString());
		//GUI.Label (new Rect (0, 60, 200, 200), "  Full Beers: " + GlobalVars.FullBeerCan.numFullCans.ToString());
		//GUI.Label (new Rect (0, 70, 200, 200), "Mittens: " + GlobalVars.Mittens.numMittens.ToString());
		//GUI.Label (new Rect (0, 90, 200, 200), "Muffins: " + GlobalVars.Muffins.numMuffins.ToString());

		//GUI.Label (new Rect (100, 50, 200, 200), "Health: " + GlobalVars.iFeltaThiHealth.ToString());
		//GUI.Label (new Rect (800, 50, 200, 200), "Health: " + GlobalVars.enemyFratHealth.ToString());
		GUI.Label (new Rect (Screen.width/2 - 100, Screen.height - 50, 200, 200), " " + GlobalVars.resourcePoint.ToString());
		if(Time.timeScale == 0.0f && StartUp.isStart == false)
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), pauseScreen);
		}
	}
}
