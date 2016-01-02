using UnityEngine;
using System.Collections;

public class RubbleDestroy : MonoBehaviour {

	public float rubbleLife = 2.0f;
	public float rubbleTime;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		rubbleTime += Time.deltaTime;
		if(rubbleTime > rubbleLife)
		{
			Destroy (gameObject);
		}
	}
}
