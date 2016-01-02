using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	public GameObject cloudsLeft;
	public GameObject cloudsRight;

	public Sprite Cloud1;
	public Sprite Cloud2;
	public Sprite Cloud3;
	public Sprite Cloud4;

	Vector2 startpos;
	public float spawnTimeLeft = 2;
	public float spawnTimeRight = 3;
	float timer1 = 0;
	float timer2 = 0;
	public float cloudHeight;
	// Use this for initialization
	void Start () 
	{
		startpos = transform.position;
		runCloudsRight();
		runClouldsLeft();
		cloudHeight = Random.Range (0, 50);
	}

	Sprite changeSprite()
	{
		int rand = Random.Range(0, 4);
		
		switch(rand)
		{
		case 0:
			return Cloud1;
		case 1:
			return Cloud2;
		case 2:
			return Cloud3;
		case 3:
			return Cloud4;
			
		default:
			return Cloud1;
			
		}
	}

	// Update is called once per frame
	void Update () 
	{
		timer1 += Time.deltaTime;
		timer2 += Time.deltaTime;
		if ( timer1 >= spawnTimeLeft)
		{
			runClouldsLeft();
			timer1 = 0;
		}
		if(timer2 >= spawnTimeRight)
		{
			runCloudsRight();
			timer2 = 0;
		}
		
	}

	void runClouldsLeft()
	{
		cloudsLeft.GetComponent<SpriteRenderer>().sprite = changeSprite();
		cloudHeight = Random.Range (0, 20);
		Instantiate(cloudsLeft, new Vector2(60,startpos.y+cloudHeight), Quaternion.identity);
	}

	void runCloudsRight()
	{
		cloudsRight.GetComponent<SpriteRenderer>().sprite = changeSprite();
		cloudHeight = Random.Range (0, 20);
		Instantiate(cloudsRight, new Vector2(-60,startpos.y+cloudHeight), Quaternion.identity);
	}
}
