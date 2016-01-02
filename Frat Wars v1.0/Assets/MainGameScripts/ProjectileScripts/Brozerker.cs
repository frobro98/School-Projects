using UnityEngine;
using System.Collections;

public class Brozerker : MonoBehaviour {

	public GameObject brozerker;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "pPledge")
		{
			SoundController.playBrozerkerSpawn = true;
			Destroy(col.gameObject);
			Instantiate (brozerker, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

	}
}
