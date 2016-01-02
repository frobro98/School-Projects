using UnityEngine;
using System.Collections;

public class ToolTips : MonoBehaviour {

	public static bool mittensInfo;
	public static bool muffinsInfo;
	public static bool helmetInfo;

	public static bool FratBroInfo;
	public static bool BeerBroInfo;
	public static bool BrosidonInfo;

	public Texture mittensInfoTexture;
	public Texture muffinsInfoTexture;
	public Texture helmetInfoTexture;

	public Texture FratBroInfoTexture;
	public Texture BeerBroInfoTexture;
	public Texture BrosidonInfoTexture;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Rect fratbroRect = new Rect(30, 0 , 80, 80);
		if(fratbroRect.Contains(Input.mousePosition) && StartUp.isStart == false)
		{
			FratBroInfo = true;
		}
		else{FratBroInfo = false;}
		Rect beerbroRect =new Rect(130 , 0 , 80, 80);
		if(beerbroRect.Contains(Input.mousePosition) && StartUp.isStart == false)
		{
			BeerBroInfo = true;
		}
		else{BeerBroInfo = false;}
		Rect brosidonRect =new Rect(240 , 0 , 80, 80);
		if(brosidonRect.Contains(Input.mousePosition) && StartUp.isStart == false)
		{
			BrosidonInfo = true;
		}
		else{BrosidonInfo = false;}

		Rect mittensRect =new Rect(10 , 680 , 80, 80);
		if(mittensRect.Contains(Input.mousePosition) && StartUp.isStart == false)
		{
			mittensInfo = true;
		}
		else{mittensInfo = false;}
		Rect muffinsRect =new Rect(10 , 590 , 80, 80);
		if(muffinsRect.Contains(Input.mousePosition) && StartUp.isStart == false)
		{
			muffinsInfo = true;
		}
		else{muffinsInfo = false;}
		Rect helmetRect =new Rect(10 , 500 , 80, 80);
		if(helmetRect.Contains(Input.mousePosition) && StartUp.isStart == false)
		{
			helmetInfo = true;
		}
		else{helmetInfo = false;}


	}

	void OnGUI()
	{
		if(mittensInfo == true)
		{
			GUI.DrawTexture(new Rect(770,650,200,100), mittensInfoTexture);
		}
		if(muffinsInfo == true)
		{
			GUI.DrawTexture(new Rect(770,650,200,100), muffinsInfoTexture);
		}
		if(helmetInfo == true)
		{
			GUI.DrawTexture(new Rect(770,650,200,100), helmetInfoTexture);
		}
		if(FratBroInfo == true)
		{
			GUI.DrawTexture(new Rect(770,650,200,100), FratBroInfoTexture);
		}
		if(BeerBroInfo == true)
		{
			GUI.DrawTexture(new Rect(770,650,200,100), BeerBroInfoTexture);
		}
		if(BrosidonInfo == true)
		{
			GUI.DrawTexture(new Rect(770,650,200,100), BrosidonInfoTexture);
		}
	}
}
