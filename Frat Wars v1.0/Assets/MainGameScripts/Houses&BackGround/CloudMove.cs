using UnityEngine;
using System.Collections;

public class CloudMove : MonoBehaviour {

	public float Speed;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale != 0.0)
		{
			transform.Translate(Speed,0,0);
		}
		if(transform.position.x >= 70 || transform.position.x <= -70)
		{
			Destroy(gameObject);
		}
	}
}
