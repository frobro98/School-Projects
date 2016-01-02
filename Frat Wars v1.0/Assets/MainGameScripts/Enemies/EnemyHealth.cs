using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	//health and damage
	public float eHealth;
	public float eDamage;
	public static bool isDead = false;

	//health bar variables
	public Texture backgroundTexture;
	public Texture foregroundTexture;
	public Texture midHealthTexture;
	public Texture lowHealthTexture;
	public Texture frameTexture;

	float healthWidth;
	public float healthHeight = 10;
	
	float frameWidth;
	public float frameHeight = 11;

	public float reward;
	float reHealth;
	public GameObject rewardPoint;

	Vector2 point;
	float startHealth;
	float curHealth;

	//enemy classes for reference
	public static class efratBro
	{
		public static float efratBroHealth = 7f;
		public static float efratBroDamage = 0.5f;
	}
	public static class ebeerBro
	{
		public static float ebeertBroHealth = 10f;
		public static float ebeerBroDamage = 1f;
	}
	public static class ebrosidon
	{
		public static float ebrosidonHealth = 15.0f;
		public static float ebrosidonDamage = 2.0f;
	}

	void Start () 
	{
		curHealth = eHealth;
		startHealth = eHealth;
		reHealth = eHealth;
		healthWidth = eHealth * 4f;
		frameWidth = eHealth * 4f + 1;
	}
	
	void Update () 
	{
		//cheack if dead
		if(eHealth < 0.0f)
		{
			//SoundController.playMaleGrunt = true;
			Instantiate(rewardPoint,transform.position, Quaternion.identity);
			GlobalVars.resourcePoint += reward;
			Destroy(gameObject);
		}

		//Calculate health bar pos
		point = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, 1));
		//Calculate health bar length
		if( startHealth != eHealth && healthWidth >= 0)
		{
			healthWidth = eHealth * 4.0f;
			startHealth = eHealth;
		}

		if(eHealth >= curHealth/5.0f && eHealth <= curHealth/2.0f)
		{
			foregroundTexture = midHealthTexture;
		}
		else if(eHealth < curHealth/5.0f )
		{
			foregroundTexture = lowHealthTexture;
		}
	}

	//GUI for healthbars
	void OnGUI () 
	{
		GUI.DrawTexture( new Rect(point.x - 12,point.y, frameWidth, frameHeight), backgroundTexture);
		GUI.DrawTexture( new Rect(point.x - 12,point.y,frameWidth,frameHeight), frameTexture);
		GUI.DrawTexture( new Rect(point.x - 11.5f,point.y + 0.5f,healthWidth, healthHeight), foregroundTexture);	
	}

	//Collisions on hit once
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "rubble")
		{
			eHealth -= 5.0f;
		}

		//collisions with projectiles
		else if(col.gameObject.tag == "EmptyCan")
		{
			eHealth -= 3.0f;
		}
		else if(col.gameObject.tag == "Mittens")
		{
			GlobalVars.resourcePoint += 100f;
			eHealth -= 20.0f;
		}
	}

	//Collisions on stay
	void OnCollisionStay2D(Collision2D col)
	{
		//collisions with players
		if(col.gameObject.tag == "pPledge")
		{
			eHealth -= PledgeHealth.pledge.pledgeDamage;
		}
		else if(col.gameObject.tag == "pFratBro")
		{
			eHealth -= PledgeHealth.fratBro.fratBroDamage;
		}
		else if(col.gameObject.tag == "pBeerBro")
		{
			eHealth -= PledgeHealth.beerBro.beerBroDamage;
		}
		else if(col.gameObject.tag == "pBrosidon")
		{
			eHealth -= PledgeHealth.brosidon.brosidonDamage;
		}
		else if(col.gameObject.tag == "pBrozerker")
		{
			eHealth -= 20;
		}
	

		//colision with house
		else if(col.gameObject.tag == "FratHouse")
		{
			GlobalVars.iFeltaThiHealth -= eDamage;
			Destroy(gameObject);
		}
	
	}



}
