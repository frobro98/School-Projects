using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float Speed = -0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale != 0.0)
		{
			transform.Translate(Speed,0,0);
		}
	}
}
