using UnityEngine;
using System.Collections;

public class Player2_UpperBody_Animation : MonoBehaviour {
	private int weapon = 0;
	private Animator animate;
	// Use this for initialization
	void Start () {
		animate = GameObject.Find ("Player2").GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		animate.SetInteger ("Weapon", weapon);
		
		if(Input.GetButtonDown("Player2_Attack")){
			animate.SetTrigger("Attack");
		}
	}
	
	public void weaponChange(int num)
	{
		weapon = num;
	}
}
