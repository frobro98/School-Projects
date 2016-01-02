using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	
	public AudioClip MuffinsMeow;
	public static bool playMuffinsMeow = false;

	public AudioClip MittensMeow;
	public static bool playMittensMeow = false;

	public AudioClip CanOpening;
	public static bool playCanOpening = false;

	public AudioClip FratBroSpawn;
	public static bool playFratBroSpawn = false;
	public AudioClip FratBroDeath;
	public static bool playFratBroDeath= false;

	public AudioClip BeerBroSpawn;
	public static bool playBeerBroSpawn = false;
	public AudioClip BeerBroDeath;
	public static bool playBeerBroDeath = false;

	public AudioClip BrosidonSpawn;
	public static bool playBrosidonSpawn = false;
	public AudioClip BrosidonDeath;
	public static bool playBrosidonDeath = false;

	public AudioClip Brozerker;
	public static bool playBrozerkerSpawn = false;

	public AudioClip SlingShot;
	public static bool playSlingShot = false;

	public AudioClip Ting;
	public static bool playTing = false;

	public AudioClip BackGround;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Projectiles
		if(playMuffinsMeow)
		{
			playMuffinsMeow = false;
			audio.PlayOneShot(MuffinsMeow);
		}
		if(playMittensMeow)
		{
			playMittensMeow = false;
			audio.PlayOneShot(MittensMeow);
		}
		if(playCanOpening)
		{
			playCanOpening = false;
			audio.PlayOneShot(CanOpening);
		}
		//FratBro
		if(playFratBroSpawn)
		{
			playFratBroSpawn = false;
			audio.PlayOneShot(FratBroSpawn);
		}
		if(playFratBroDeath)
		{
			playFratBroDeath = false;
			audio.PlayOneShot(FratBroDeath);
		}
		//BeerBro
		if(playBeerBroSpawn)
		{
			playBeerBroSpawn = false;
			audio.PlayOneShot(BeerBroSpawn);
		}
		if(playBeerBroDeath)
		{
			playBeerBroDeath = false;
			audio.PlayOneShot(BeerBroDeath);
		}
		//Brosidon
		if(playBrosidonSpawn)
		{
			playBrosidonSpawn = false;
			audio.PlayOneShot(BrosidonSpawn);
		}
		if(playBrosidonDeath)
		{
			playBrosidonDeath = false;
			audio.PlayOneShot(BrosidonDeath);
		}

		if(playBrozerkerSpawn)
		{
			playBrozerkerSpawn = false;
			audio.PlayOneShot(Brozerker);
		}
		if(playSlingShot)
		{
			playSlingShot = false;
			audio.PlayOneShot(SlingShot);
		}
		if(playTing)
		{
			playTing = false;
			audio.PlayOneShot(Ting);
		}
	}
}
