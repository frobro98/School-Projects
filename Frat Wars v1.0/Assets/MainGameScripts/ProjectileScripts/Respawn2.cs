using UnityEngine;
using System.Collections;

public class Respawn2 : MonoBehaviour {

	Stack projRespawn = new Stack();

	//Sprites
	public Sprite can;
	public Sprite fullCan;
	public Sprite armChair;
	public Sprite trashCan;
	public Sprite bowlingBall;
	public Sprite soloCup;
	public Sprite flipFlop;
	public Sprite toiletPaper;
	public Sprite toiletBowl;
	public Sprite tire;
	public Sprite keg;
	public Sprite pizza;
	
	//Projectiles
	public GameObject emptyCan;
	public GameObject mittens;
	public GameObject muffins;
	public GameObject brozerkerHelmet;

	//ButtonTextures
	public Texture2D Helmet;
	public Texture2D GetMittensButton;
	public Texture2D GetMuffinsButton;
	
	public Texture2D greyHelmet;
	public Texture2D greyGetMittensButton;
	public Texture2D greyGetMuffinsButton;
	
	private GameObject currObj;
	private GameObject[] currObjs;
	//private info objInfo;
	
	public static bool canFireSlingshot = true;
	float timer;
	// Use this for initialization
	void Start () 
	{
		canFireSlingshot = true;
	}
	
	Sprite changeSprite()
	{
		int rand = Random.Range(0, 12);
		
		switch(rand)
		{
		case 0:
			return can;

		case 1:
			return fullCan;

		case 2:
			return armChair;

		case 3:
			return trashCan;
			
		case 4:
			return bowlingBall;

		case 5:
			return soloCup;
			
		case 6:
			return flipFlop;
			
		case 7:
			return toiletPaper;
			
		case 8:
			return toiletBowl;
			
		case 9:
			return tire;
			
		case 10:
			return keg;
			
		case 11:
			return pizza;
			
		default:
			return can;
			
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameObject.FindGameObjectsWithTag("EmptyCan").Length <= 0 && GameObject.FindGameObjectsWithTag("Muffins").Length <= 0 && GameObject.FindGameObjectsWithTag("Mittens").Length <= 0 && GameObject.FindGameObjectsWithTag("Brozerker").Length <= 0)
		{
			canFireSlingshot = true;
		}
		if(projRespawn.Count <= 6)
		{
			//shootScript.changeSprite();
			emptyCan.GetComponent<SpriteRenderer>().sprite = changeSprite();
			projRespawn.Push(emptyCan);
		}
		if(canFireSlingshot == true)
		{
			timer += Time.deltaTime;
		}

		if(canFireSlingshot && timer >= 1.0f)
		{
			Instantiate((GameObject) projRespawn.Pop(), transform.position, transform.rotation);
			timer = 0;
			canFireSlingshot = false;
		}

	}
	
	void OnGUI()
	{

		if(SpendResources.canFireMittens && StartUp.isStart == false )
		{
			if (GUI.Button(new Rect(10, 10, 80, 80), GetMittensButton, GUIStyle.none) || Input.GetKey(KeyCode.Alpha1))
			{
				SoundController.playMittensMeow = true;
				projRespawn.Push(mittens);
				SpendResources.canFireMittens = false;
			}
		}
		else if (SpendResources.canFireMittens == false && StartUp.isStart == false)
		{
			GUI.Button(new Rect(10, 10, 80, 80), greyGetMittensButton, GUIStyle.none);
		}
		
		if(SpendResources.canFireMuffins && StartUp.isStart == false)
		{
			if (GUI.Button(new Rect(10, 100, 80, 80),GetMuffinsButton, GUIStyle.none) || Input.GetKey(KeyCode.Alpha2))
			{
				SoundController.playMuffinsMeow = true;
				projRespawn.Push(muffins);
				SpendResources.canFireMuffins = false;
			}
		}
		else if (SpendResources.canFireMuffins == false && StartUp.isStart == false)
		{
			GUI.Button(new Rect(10, 100, 80, 80), greyGetMuffinsButton, GUIStyle.none);
		}
		
		if(SpendResources.canFireHelmet && StartUp.isStart == false)
		{
			if (GUI.Button(new Rect(10, 190, 80, 80),Helmet, GUIStyle.none) || Input.GetKey(KeyCode.Alpha3))
			{
				//SOUND HERE
				SoundController.playCanOpening = true;
				projRespawn.Push(brozerkerHelmet);
				SpendResources.canFireHelmet = false;
				//canFireSlingshot = false;
			}
		}
		else if (SpendResources.canFireHelmet == false && StartUp.isStart == false)
		{
			GUI.Button(new Rect(10, 190, 80, 80), greyHelmet, GUIStyle.none);
		}
		
	}
}