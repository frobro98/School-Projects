using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {

	static public float iFeltaThiStartHealth = 10.0f;
	static public float iFeltaThiHealth = 10.0f;

	static public float enemyFratStartHealth = 15.0f;
	static public float enemyFratHealth = 15.0f;

	static public float resourcePoint = 0.0f;

	public static class EmptyBeerCan
	{
		public static float emptyCanDamage = 0.1f;
	}

	public static class FullBeerCan
	{
		public static int numFullCans = 0;
		public static int fullCanPrice = 1;
		public static float fullCanDamage = 0.5f;
	}

	public static class Mittens
	{
		public static int numMittens = 0;
		public static int mittensPrice = 10;
		public static float mittensDamage = 1.0f;
	}

	public static class Muffins
	{
		public static int numMuffins = 0;
		public static int muffinsPrice = 20;
		public static float muffinsDamage = 2.0f;
	}
	// Use this for initialization
	void Start () 
	{

	}
	// Update is called once per frame
	void Update () 
	{
	
	}
}
