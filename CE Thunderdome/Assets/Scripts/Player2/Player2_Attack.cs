using UnityEngine;
using System.Collections;

public class Player2_Attack : MonoBehaviour {
	
	public float force = .1f; // adjust the impact force
	Vector3 dir; // used to hold the direction the opponent is hit it
	bool canHit = false; //boolean for if opponent can be hit or not
	Collider2D opponent; //holds the opponents data to apply attacks to
	public Player1_Take_Damage giveDamage; //reference to opponents damage script 
	public Player2_UpperBody_Animation updateAnimation;
	public int attackType = 0; //determine what type of attack is done based on current weapon
	public GameObject staple; //stapler prefab
	int useCount = 0; //used to count weapon uses 
	public GameObject origin; //object used as start of projectile paths
	
	//Opponent can be hit if inside your trigger collider 
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player1") {
			Debug.Log ("In melee range");
			canHit = true;
			opponent = other;
		}
	}

	//opponent can NOT be hit if he leave your trigger collider
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "Player1") {
			Debug.Log ("out of melee range");
			canHit = false;
		}
	}
	
	
	void Update () {

		if (attackType == 0) //if no weapon equiped 
		{
			if (canHit) //if the opponent is in range, press attack button to punch him 
			{
				dir = opponent.transform.position - transform.position;
				
				if (Input.GetButtonDown ("Player2_Attack")) 
				{
					opponent.rigidbody2D.AddForce (dir.normalized * force);
					giveDamage.RecieveDamage (10, dir);
				}
			}
			
		}

		else if(attackType == 1) // if stapler equipped 
		{
			//faire staple projectile when attack button is pressed 
			if (Input.GetButtonDown ("Player2_Attack")) 
			{
				GameObject stapleObj = GameObject.Instantiate (staple, origin.transform.position, origin.transform.rotation)as GameObject;
				useCount++;
			}
			
			//drop weapon after 8 projectiles 
			if(useCount >= 8)
			{
				updateAttackType(0);
				useCount = 0;
			}
		}
		
	}

	//function used to change what attack type is used
	public void updateAttackType(int num)
	{
		attackType = num;
		updateAnimation.weaponChange (num);
	}

	public int getAttackType()
	{
		return attackType;
		
	}

}
