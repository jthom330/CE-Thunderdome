using UnityEngine;
using System.Collections;

public class Stapler_Equip : MonoBehaviour {
	

	bool p1Equip = false;
	bool p2Equip = false;
	public Player1_Attack p1Staple;
	public Player2_Attack p2Staple;
	public GameObject Aprompt;
	
	//When player enters staple equip area, they may pick up the stapler
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player1") {
			Debug.Log ("Player1 in equip range");
			p1Equip = true;

		} 

		if (other.gameObject.name == "Player2") {
			Debug.Log ("Player2 in equip range");
			p2Equip = true;
		}
	}

	//When player leave staple equip area, they may not pick it up
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "Player1") {
			p1Equip = false;
			
		} 

		if (other.gameObject.name == "Player2") {
			p2Equip = false;
		}
	}
	
	
	void Update () {
		
		if(p1Equip) //if Player 1 is in the pickup area, hit 'A' to equip
		{
			Aprompt.renderer.enabled = true;
			if (Input.GetButtonDown ("Player1_Pickup")) {
				if(p1Staple.getAttackType() ==0 )
				{
					p1Staple.updateAttackType(1);
					Destroy(gameObject); //stapler is destroyed after pickup
				}
			}
		}


		if(p2Equip) //if Player 1 is in the pickup area, hit 'A' to equip
		{
			Aprompt.renderer.enabled = true;
			if (Input.GetButtonDown ("Player2_Pickup")) {
				if(p2Staple.getAttackType() ==0 )
				{
					p2Staple.updateAttackType(1);
					Destroy(gameObject);//stapler is destroyed after pickup
				}
			}
		}

		if (p2Equip == false && p1Equip == false)
		{
			Aprompt.renderer.enabled = false;
		}
		
	}
	
}
