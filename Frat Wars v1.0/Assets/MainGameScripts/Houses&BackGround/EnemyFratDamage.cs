using UnityEngine;
using System.Collections;

public class EnemyFratDamage : MonoBehaviour {

	public Sprite damage1;
	public Sprite damage2;
	public Sprite damage3;
	public Sprite damage4;
	
	private SpriteRenderer spriteRenderer; 
	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update ()
	{
		if(GlobalVars.enemyFratHealth <= GlobalVars.enemyFratStartHealth * 0.8f)
		{
			spriteRenderer.sprite = damage1;
		}
		if(GlobalVars.enemyFratHealth <= GlobalVars.enemyFratStartHealth * 0.6f)
		{
			spriteRenderer.sprite = damage2;
		}
		if(GlobalVars.enemyFratHealth <= GlobalVars.enemyFratStartHealth * 0.4f)
		{
			spriteRenderer.sprite = damage3;
		}
		if(GlobalVars.enemyFratHealth <= GlobalVars.enemyFratStartHealth * 0.2f)
		{
			spriteRenderer.sprite = damage4;
		}
	}
}
