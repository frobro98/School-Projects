using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	GameObject enemy;

	public GameObject eFratBro;
	public GameObject eBeerBro;
	public GameObject eBrosidon;
	Vector2 spawnPosition;
	public float timeStart = 5.0f;
	public float timer;

	float curhealth;

	public float randTimer;
	public float getRandom;
	public int enemyRange = 99;

	public float FratBroRange = 80;
	public float BeerBroRangestart = 80;
	public float BeerBroRangeend = 100;
	public float BrosidonRangestart = 100;
	public float BrosidonRangeend = 100;
	// Use this for initialization
	void Start () 
	{
		//Random.seed = (int)Time.deltaTime;
		spawnPosition.Set(transform.position.x,transform.position.y);
		//enemy = GameObject.FindGameObjectWithTag("Enemy");
		timer = timeStart;
		//getRandom = Random.Range(1,enemyRange);
		enemy = eFratBro;

		curhealth = GlobalVars.enemyFratHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(getRandom <= FratBroRange)
		{
			enemy = eFratBro;
	
		}
		if( getRandom > BeerBroRangestart && getRandom <= BeerBroRangeend)
		{
			enemy = eBeerBro;
		}
		if( getRandom > BrosidonRangestart && getRandom <= BrosidonRangeend)
		{
			enemy = eBrosidon;
		}
		//*/
		timer -= Time.deltaTime;
		if(timer < 0)
		{
			Instantiate(enemy, spawnPosition, Quaternion.identity);
			getRandom = Random.Range(1,enemyRange);
			timer = timeStart;
		}
		if(GlobalVars.enemyFratHealth <= curhealth - 1) //healthbased
		{
			timeStart -= 0.2f;
			curhealth -= 1f;

			FratBroRange -= 3.8f;
			BeerBroRangestart -= 3.8f;
			BeerBroRangeend -= 3.8f;
			BrosidonRangestart -= 3.8f;
		}
	

	}
}

