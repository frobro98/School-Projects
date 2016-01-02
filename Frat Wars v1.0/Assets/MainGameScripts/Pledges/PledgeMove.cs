using UnityEngine;
using System.Collections;

public class PledgeMove : MonoBehaviour {

	public float moveX = 0.15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale != 0.0)
		{
			transform.Translate(moveX,0.0f,0.0f);
		}
	}
}
