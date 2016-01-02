using UnityEngine;
using System.Collections;

public class MuffinsHit : MonoBehaviour {

	public GameObject Rubble;
	public float randx;
	public float randy;
	bool oneHit = true;
	public float force = 10;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Ground" && oneHit == true)
		{
			oneHit = false;
			//Instantiate(AoE,transform.position, Quaternion.identity);
			for (int i = 0 ; i < 20 ; i++)
			{
				//randx = Random.Range(-200, 200);
				//randy = Random.Range (0, 10);
				Instantiate(Rubble,transform.position, Quaternion.identity);
				//Rubble.rigidbody2D.AddForce(new Vector2(transform.position.x + randx, transform.position.y + randy));
			}
		}
		GameObject[] rubblePieces = GameObject.FindGameObjectsWithTag("rubble");
		for(int i = 0 ; i < rubblePieces.Length ; i++)
		{
			randx = Random.Range(-800, 800);
			randy = Random.Range (50, 800);
			rubblePieces[i].rigidbody2D.AddForce(new Vector2(transform.position.x + randx, transform.position.y + randy));
		}
	}

}
