using UnityEngine;
using System.Collections;

public class KillBrozerker : MonoBehaviour {

	public float timer = 0;
	public GameObject rewardPoint;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if(timer > 4)
		{
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		//collision with house
		if(col.gameObject.tag == "NewHouse")
		{
			GlobalVars.enemyFratHealth -= 1.0f;
			Instantiate(rewardPoint,transform.position, transform.rotation);
			GlobalVars.resourcePoint += 100;
			Destroy (gameObject);
		}
	}
}
