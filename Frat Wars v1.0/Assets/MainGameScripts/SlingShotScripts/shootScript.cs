using UnityEngine;
using System.Collections;

public class shootScript : MonoBehaviour {
	
	
	private Rigidbody2D rigidbody;
	private SpringJoint2D spring;
	
	public bool deleteSpring;
	private const float maxRadius = 7.0f;
	public float radius;
	private GameObject projSpawner;
	private Vector3 gamePos;
	private Vector3 spawnPos;
	
	private Vector2 prevVeocity;
	private float timer = 0f;
	private bool clicked = false;
	
	private bool rotating = false;
	public static float addRot = 0;
	public Vector3 screenPoint;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		prevVeocity = Vector2.zero;
		
		rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
		spring = this.gameObject.GetComponent<SpringJoint2D>();
		
		rigidbody.isKinematic = true;
		rigidbody.fixedAngle = true;
		deleteSpring = false;
		
		projSpawner = GameObject.FindGameObjectWithTag("Respawn");
		
		spawnPos = projSpawner.transform.position;
		gamePos = gameObject.transform.position;
		radius = Vector2.Distance(new Vector2(gamePos.x, gamePos.y),
		                          new Vector2(spawnPos.x, spawnPos.y));
		
		
	}
	
	private Vector2 findNewRadiusCoords()
	{
		float x = gamePos.x - spawnPos.x;
		float y = gamePos.y - spawnPos.y;
		
		float correctedX = (x * maxRadius) / radius;
		float correctedY = (y * maxRadius) / radius;
		
		return new Vector2(spawnPos.x + correctedX,
		                   spawnPos.y + correctedY);
	}
	
	void OnMouseDown(){
		//clicked = true;
		
		rigidbody.isKinematic = false;
		//rigidbody.gravityScale = 0f;
		spring.enabled = false;
		
		rigidbody2D.velocity = Vector3.zero;
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (
			new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPos = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		
		gamePos = new Vector2(curPos.x, curPos.y);
		radius = Vector2.Distance(new Vector2(gamePos.x, gamePos.y),
		                          new Vector2(spawnPos.x, spawnPos.y));
		if(radius > maxRadius)
		{
			gameObject.transform.position = findNewRadiusCoords();
		}
		else
		{
			gameObject.transform.position = curPos;
		}
	}
	
	void OnMouseUp()
	{
		//clicked = false;
		//Debug.Break();
		rigidbody.isKinematic = false;
		//if(timer >= .5f)
		//rigidbody.gravityScale = 1;
		spring.enabled = true;
		
		
		SoundController.playSlingShot = true;
		//Vector3 pos = gameObject.transform.position;
		//Vector2 negForce = gameObject.transform.InverseTransformDirection(new Vector2(pos.x, pos.y));
		//rigidbody.AddForce(negForce);
		
		deleteSpring = true;
		rotating = true;
		Respawn2.canFireSlingshot = true;
		
	}
	
	
	
	
	// Update is called once per frame
	void Update () 
	{
		radius = Vector2.Distance(new Vector2(gamePos.x, gamePos.y),
		                          new Vector2(spawnPos.x, spawnPos.y));
		//if(!clicked)
		//	timer += Time.deltaTime;
		
		if(spring != null && deleteSpring)
		{
			if(/*timer > .75f || */!rigidbody.isKinematic && rigidbody.velocity.sqrMagnitude > 5f && prevVeocity.sqrMagnitude > rigidbody.velocity.sqrMagnitude)
			{
				//Debug.Break();
				rigidbody.velocity = prevVeocity;
				Destroy (spring);
				timer = 0;
			}
			
			if(!clicked)
				prevVeocity = rigidbody.velocity;
			
			
			/*
			if(timer > 1f && spring.enabled == false)
			{
				spring.enabled = true;
				spring.enabled = false;
				timer = 0f;
			}//*/
			
			
			//prevVeocity = rigidbody.velocity;
		}
		//*
		if(rotating)
		{
			if(addRot >= 360)
			{
				addRot = 360;
			}
			else if(addRot <= -360)
			{
				addRot = -360;
			}
			transform.RotateAround(transform.position, new Vector3(0,0,1), (-45+addRot) * Time.deltaTime);
		}
		//*/

		/*
		if(deleteSpring)
		{
			if(radius >= maxRadius - 1.0f)
			{
				Destroy(spring);
				deleteSpring = false;
			}
		}//*/
	}
}