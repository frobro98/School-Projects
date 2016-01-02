using UnityEngine;
using System.Collections;

public class PledgeHealth : MonoBehaviour {

	public float pHealth;
	public float pDamage;

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
	
	Vector2 point;
	float startHealth;
	float curHealth;
	float startingHealth;

	public GameObject rewardPoint;

	public float damageReduction;
	//Bro classes for reference
	public static class pledge
	{
		public static float pledgeHealth = 2;
		public static float pledgeDamage = 1.0f;

	}
	public static class fratBro
	{
		public static float fratBroCost = 500;
		public static float fratBroHealth = 9f;
		public static float fratBroDamage = 1.0f;
	}
	public static class beerBro
	{
		public static float beerBroCost = 1000;
		public static float beertBroHealth = 15.0f;
		public static float beerBroDamage = 1.0f;
	}
	public static class brosidon
	{
		public static float brosidonCost = 3000;
		public static float brosidonHealth = 20.0f;
		public static float brosidonDamage = 4.0f;
	}

	void Start () 
	{
		startingHealth = pHealth;
		curHealth = pHealth;
		startHealth = pHealth;
		healthWidth = pHealth * 4f;
		frameWidth = pHealth * 4f + 1;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Calculate health bar pos
		point = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, 0));
		//Calculate health bar length
		if( startHealth != pHealth && healthWidth > 0)
		{
			healthWidth = pHealth * 4f;
			startHealth = pHealth;
		}
		if(pHealth >= curHealth/5.0f && pHealth <= curHealth/2.0f)
		{
			foregroundTexture = midHealthTexture;
		}
		if(pHealth < curHealth/5.0f )
		{
			foregroundTexture = lowHealthTexture;
		}

		//death check
		if(pHealth <= 0)
		{
			//SoundController.playMaleGrunt = true;
			if(startingHealth == brosidon.brosidonHealth){SoundController.playFratBroDeath = true;}
			if(startingHealth == beerBro.beertBroHealth){SoundController.playBeerBroDeath = true;}
			if(startingHealth == fratBro.fratBroHealth){SoundController.playBrosidonDeath = true;}
			Destroy(gameObject);
		}
	}

	//GUI for healthbars
	void OnGUI () 
	{
		GUI.DrawTexture( new Rect(point.x - 12,point.y , frameWidth, frameHeight), backgroundTexture);
		GUI.DrawTexture( new Rect(point.x - 12,point.y ,frameWidth,frameHeight), frameTexture);
		GUI.DrawTexture( new Rect(point.x - 11.5f,point.y + 0.5f,healthWidth, healthHeight), foregroundTexture);	
	}

	//Collisions
	void OnCollisionStay2D(Collision2D col)
	{
		//collisions with enemies
		if(col.gameObject.tag == "eFratBro")
		{
			pHealth -= EnemyHealth.efratBro.efratBroDamage - damageReduction;
		}
		if(col.gameObject.tag == "eBeerbro")
		{
			pHealth -= EnemyHealth.ebeerBro.ebeerBroDamage - damageReduction;
		}
		if(col.gameObject.tag == "eBrosidon")
		{
			pHealth -= EnemyHealth.ebrosidon.ebrosidonDamage - damageReduction;
		}

		//collision with house
		if(col.gameObject.tag == "NewHouse")
		{
			GlobalVars.enemyFratHealth -= pDamage;
			if(startingHealth == fratBro.fratBroHealth)
			{
				Instantiate(rewardPoint,transform.position, Quaternion.identity);
			}
			else
			{
				Instantiate(rewardPoint,transform.position, transform.rotation);
			}
			GlobalVars.resourcePoint += 100;
			Destroy(gameObject);
		}
	}
}
