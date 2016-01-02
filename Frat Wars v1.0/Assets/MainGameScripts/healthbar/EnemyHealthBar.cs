using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {
	public Texture backgroundTexture;
	public Texture foregroundTexture;
	public Texture midHealthTexture;
	public Texture lowHealthTexture;
	public Texture frameTexture;
	
	float healthWidth = GlobalVars.enemyFratStartHealth * 10;
	public float healthHeight = 20;
	
	float frameWidth  = (GlobalVars.enemyFratStartHealth * 10) + 6;
	public float frameHeight = 26;
	
	Vector2 startpos;
	Vector2 point;
	
	float baseHealth;
	void Start()
	{
		baseHealth = GlobalVars.enemyFratStartHealth;
		startpos.Set(transform.position.x,-transform.position.y);
	}
	
	void Update()
	{
		point = Camera.main.WorldToScreenPoint(startpos);
		if(baseHealth != GlobalVars.enemyFratHealth && healthWidth > 0)
		{
			healthWidth = GlobalVars.enemyFratHealth * 10;
			baseHealth = GlobalVars.enemyFratHealth;
			
		}
		if(GlobalVars.enemyFratHealth >= GlobalVars.enemyFratStartHealth/10.0f && GlobalVars.enemyFratHealth <= GlobalVars.enemyFratStartHealth/2.0f)
		{
			foregroundTexture = midHealthTexture;
		}
		if(GlobalVars.enemyFratHealth <= GlobalVars.enemyFratStartHealth/10.0f )
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
