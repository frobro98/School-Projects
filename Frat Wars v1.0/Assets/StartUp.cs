using UnityEngine;
using System.Collections;

public class StartUp : MonoBehaviour {

	public static bool isStart = true;

	public Texture infoPage1;
	public Texture infoPage2;
	public Texture infoPage3;

	public Texture curTexture;
	// Use this for initialization
	void Start () 
	{
		isStart = true;
		curTexture = infoPage1;
		Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.anyKeyDown && curTexture == infoPage1 && isStart == true)
		{
			curTexture = infoPage2;
		}
		else if(Input.anyKeyDown && curTexture == infoPage2 && isStart == true)
		{
			curTexture = infoPage3;
		}
		else if(Input.anyKeyDown && curTexture == infoPage3 && isStart == true)
		{
			curTexture = infoPage1;
			isStart = false;
			Time.timeScale = 1.0f;
		}
	}
	void OnGUI()
	{	
		if(Time.timeScale == 0.0f && isStart == true)
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), curTexture);
		}
	}
}
