using UnityEngine;
using System.Collections;

public class MittensKill : MonoBehaviour {

	public bool start = false;
	public float timerStart = 1.0f;
	public float timer = 0.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(start == true)
		{
			timer += Time.deltaTime;
		}
		if(transform.position.x > 60.0f || transform.position.y < -100)
		{
			Destroy (gameObject);
			shootScript.addRot = 0;
		}
		if(timer > timerStart)
		{
			Destroy (gameObject);
			shootScript.addRot = 0;
			timer = 0.0f;
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Ground" && start == false)
		{
			start = true;
			shootScript.addRot += -360;
		}
		if ( c.gameObject.layer == 8 )
		{
			SoundController.playTing = true;
			Destroy (gameObject);
		}
	}
}
