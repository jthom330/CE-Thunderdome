using UnityEngine;
using System.Collections;

public class Player1_UpperBody_Animation : MonoBehaviour {
	private int weapon = 0;
	private Animator animate;
	// Use this for initialization
	void Start () {
		animate = GameObject.Find ("Player1").GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		animate.SetInteger ("Weapon", weapon);

		if(Input.GetButtonDown("Player1_Attack")){
			animate.SetTrigger("Attack");
		}
	}

	public void weaponChange(int num)
	{
		weapon = num;
	}
}
