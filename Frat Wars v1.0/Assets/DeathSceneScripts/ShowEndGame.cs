using UnityEngine;
using System.Collections;

public class ShowEndGame : MonoBehaviour {

	public Texture dead;
	// Use this for initialization
	void Start () 
	{
		GlobalVars.iFeltaThiHealth = GlobalVars.iFeltaThiStartHealth;
		GlobalVars.enemyFratHealth = GlobalVars.enemyFratStartHealth;
		GlobalVars.resourcePoint = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.anyKey)
		{
			Application.LoadLevel("StartScreen");
		}
	
	}
	void OnGUI()
	{
		GUI.Label (new Rect (300, 300, 200, 200), "GameOver ");
		GUI.DrawTexture ( new Rect (0,0,Screen.width,Screen.height),dead);
	}
}
