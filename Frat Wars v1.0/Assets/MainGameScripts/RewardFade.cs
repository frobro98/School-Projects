using UnityEngine;
using System.Collections;

public class RewardFade : MonoBehaviour {

	Color fadeOut = new Vector4(0,0,0,0);
	Color start;

	// Use this for initialization
	void Start () 
	{
		start = renderer.material.color;

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(new Vector2(0,0.2f));
		renderer.material.color -= start*0.007f;

		if(renderer.material.color.a <= .001)
		{
			Destroy(gameObject);
		}

	}
}
