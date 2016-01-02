using UnityEngine;
using System.Collections;

public class SpawnReenforcements : MonoBehaviour {

	public GameObject pledge;
	public GameObject fratBro;
	public GameObject beerBro;
	public GameObject brosidon;

	Vector2 spawnPosition;
	public float timeStart = 5.0f;
	public float timer;

	public static float spawnNum = 0;
	// Use this for initialization
	void Start () 
	{
		spawnPosition.Set(transform.position.x,transform.position.y);
		//player = GameObject.FindGameObjectWithTag("Player");
		timer = timeStart;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( spawnNum == 1)
		{
			Instantiate(fratBro, spawnPosition, Quaternion.identity);
			spawnNum = 0;
		}
		if (spawnNum == 2)
		{
			Instantiate(beerBro, spawnPosition, Quaternion.identity);
			spawnNum = 0;
		}
		if( spawnNum == 3)
		{
			Instantiate(brosidon, spawnPosition, Quaternion.identity);
			spawnNum = 0;
		}
		if(timer < 0)
		{
			timer = timeStart;
			Instantiate(pledge, spawnPosition, Quaternion.identity);
		}
		else
		{
			timer -= Time.deltaTime;
		}
	}
}
