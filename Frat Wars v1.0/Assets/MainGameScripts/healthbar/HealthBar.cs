using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	//health bar
	public Texture backgroundTexture;
	public Texture foregroundTexture;
	public Texture frameTexture;
	public Texture midHealthTexture;
	public Texture lowHealthTexture;
	
	float healthWidth = GlobalVars.iFeltaThiStartHealth * 10;
	public float healthHeight = 30;

	float frameWidth  = (GlobalVars.iFeltaThiStartHealth * 10) + 6;
	public float frameHeight = 36;

	Vector2 startpos;
	Vector2 point;

	float baseHealth;

	void Start()
	{
		baseHealth = GlobalVars.iFeltaThiStartHealth;
		startpos.Set(transform.position.x,-transform.position.y);
	}

	void Update()
	{
		point = Camera.main.WorldToScreenPoint(startpos);
		if(baseHealth != GlobalVars.iFeltaThiHealth && healthWidth > 0)
		{
			healthWidth = GlobalVars.iFeltaThiHealth * 10;
			baseHealth = GlobalVars.iFeltaThiHealth;

		}

		if(GlobalVars.iFeltaThiHealth >= GlobalVars.iFeltaThiStartHealth/10.0f && GlobalVars.iFeltaThiHealth <= GlobalVars.iFeltaThiStartHealth/2.0f)
		{
			foregroundTexture = midHealthTexture;
		}
		if(GlobalVars.iFeltaThiHealth <= GlobalVars.iFeltaThiStartHealth/10.0f )
		{
			foregroundTexture = lowHealthTexture;
		}

	}

	void OnGUI () 
	{

		GUI.DrawTexture( new Rect(point.x,point.y, frameWidth, frameHeight), backgroundTexture);
		GUI.DrawTexture( new Rect(point.x,point.y,frameWidth,frameHeight), frameTexture);
		GUI.DrawTexture( new Rect(point.x + 3,point.y + 3,healthWidth, healthHeight), foregroundTexture);
		
	}
}
