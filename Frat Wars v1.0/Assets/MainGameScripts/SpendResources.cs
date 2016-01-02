using UnityEngine;
using System.Collections;

public class SpendResources : MonoBehaviour {

	//Get textures
	public Texture2D fratBroButton;
	public Texture2D beerBroButton;
	public Texture2D brosidonButton;
	
	public Texture2D greyfratBroButton;
	public Texture2D greybeerBroButton;
	public Texture2D greybrosidonButton;

	//Texture info
	public float buttonWidth = 75.0f;
	public float buttonHeight = 75.0f;

	//timer info
	public float mittensStart = 10.0f;
	public float mittensTime = 10.0f;

	public float muffinsStart = 25.0f;
	public float muffinsTime = 25.0f;

	public float helmetStart = 25.0f;
	public float helmetTime = 25.0f;

	public static bool canFireMittens = false;
	public static bool canFireMuffins = false;
	public static bool canFireHelmet = false;


	void Start () 
	{
		//Hard Reset
		mittensTime = mittensStart;
		muffinsTime = muffinsStart;
		helmetTime = helmetStart;
		canFireMittens = false;
		canFireMuffins = false;
		canFireHelmet = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(canFireMittens == false)
		{
			mittensTime -= Time.deltaTime;
			if(mittensTime <= 0)
			{
				canFireMittens = true;
				mittensTime = mittensStart;
			}
		}
		if(canFireMuffins == false)
		{
			muffinsTime -= Time.deltaTime;
			if(muffinsTime <= 0)
			{
				canFireMuffins = true;
				muffinsTime = muffinsStart;
			}
		}
		if(canFireHelmet == false)
		{
			helmetTime -= Time.deltaTime;
			if(helmetTime <= 0)
			{
				canFireHelmet = true;
				helmetTime = helmetStart;
			}
		}
		
	}
	void OnGUI()
	{
		/* //buy beer
		if(GlobalVars.resourcePoint >= GlobalVars.FullBeerCan.fullCanPrice)
		{
			if (GUI.Button(new Rect(10, 290, 50, 60), BuyBeerButton, GUIStyle.none))
			{
				GlobalVars.resourcePoint -= GlobalVars.FullBeerCan.fullCanPrice;
				GlobalVars.FullBeerCan.numFullCans += 6;
			}
		}
		//*/
		/* //buy cats
		if(canFireMittens)
		{
			if (GUI.Button(new Rect(10, 10, 50, 50), GetMittensButton, GUIStyle.none))
			{
				GlobalVars.resourcePoint -= GlobalVars.Mittens.mittensPrice;
				GlobalVars.Mittens.numMittens += 1;
			}
		}
		else if (canFireMittens == false)
		{
			GUI.Button(new Rect(10, 10, 50, 50), greyGetMittensButton, GUIStyle.none)
		}
		
		if(canFireMuffins)
		{
			if (GUI.Button(new Rect(10, 70, 50, 50), GetMuffinsButton, GUIStyle.none))
			{
				GlobalVars.resourcePoint -= GlobalVars.Muffins.muffinsPrice;
				GlobalVars.Muffins.numMuffins += 1;
			}
		}
		else if (canFireMuffins == false)
		{
			GUI.Button(new Rect(10, 70, 50, 50), greyGetMuffinsButton, GUIStyle.none)
		}
		//*/

		//Buy Frat Bro
		if(StartUp.isStart == false)
		{
			GUI.Label (new Rect (100, 30, 80, 80), " " + (int)mittensTime);
			GUI.Label (new Rect (100, 120, 80, 80), " " + (int)muffinsTime);
			GUI.Label (new Rect (100, 210, 80, 80), " " + (int)helmetTime);
			GUI.Label (new Rect (20, Screen.height-buttonHeight-20, buttonHeight, buttonWidth), "RP:" + PledgeHealth.fratBro.fratBroCost);
			GUI.Label (new Rect (50 + buttonWidth, Screen.height-buttonHeight-20, buttonHeight, buttonWidth), "RP:" + PledgeHealth.beerBro.beerBroCost);
			GUI.Label (new Rect (80 + buttonWidth*2, Screen.height-buttonHeight-20, buttonHeight, buttonWidth), "RP:" + PledgeHealth.brosidon.brosidonCost);
		}
		if(GlobalVars.resourcePoint >= PledgeHealth.fratBro.fratBroCost && StartUp.isStart == false)
		{
			if (GUI.Button(new Rect (20, Screen.height-buttonHeight , buttonHeight, buttonWidth), fratBroButton, GUIStyle.none))
			{
				SoundController.playFratBroSpawn = true;
				GlobalVars.resourcePoint -= PledgeHealth.fratBro.fratBroCost;
				SpawnReenforcements.spawnNum = 1;
			}
		}
		else if(GlobalVars.resourcePoint <= PledgeHealth.fratBro.fratBroCost && StartUp.isStart == false)
		{
			GUI.Button(new Rect(20, Screen.height-buttonHeight , buttonHeight, buttonWidth), greyfratBroButton, GUIStyle.none);	
		}

		//Buy Beer Bro
		if(GlobalVars.resourcePoint >= PledgeHealth.beerBro.beerBroCost && StartUp.isStart == false)
		{
			if (GUI.Button(new Rect(50 + buttonWidth, Screen.height-buttonHeight , buttonHeight, buttonWidth), beerBroButton, GUIStyle.none))
			{
				SoundController.playBeerBroSpawn = true;
				GlobalVars.resourcePoint -=  PledgeHealth.beerBro.beerBroCost;
				SpawnReenforcements.spawnNum = 2;
			}

		}
		else if(GlobalVars.resourcePoint <= PledgeHealth.beerBro.beerBroCost && StartUp.isStart == false)
		{
			GUI.Button(new Rect(50 + buttonWidth, Screen.height-buttonHeight, buttonHeight, buttonWidth), greybeerBroButton, GUIStyle.none);
		}


		//Buy Brosidon
		if(GlobalVars.resourcePoint >= PledgeHealth.brosidon.brosidonCost && StartUp.isStart == false)
		{
			if (GUI.Button(new Rect(80 + (buttonWidth*2), Screen.height-buttonHeight , buttonHeight, buttonWidth), brosidonButton, GUIStyle.none))
			{
				SoundController.playBrosidonSpawn = true;
				GlobalVars.resourcePoint -=  PledgeHealth.brosidon.brosidonCost;
				SpawnReenforcements.spawnNum = 3;
			}
		}
		else if(GlobalVars.resourcePoint <= PledgeHealth.brosidon.brosidonCost && StartUp.isStart == false)
		{
			GUI.Button(new Rect(80 + (buttonWidth*2), Screen.height-buttonHeight, buttonHeight, buttonWidth), greybrosidonButton, GUIStyle.none);
		}
		
	}
}
