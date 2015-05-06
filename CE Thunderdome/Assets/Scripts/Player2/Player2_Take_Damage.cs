using UnityEngine;
using System.Collections;

public class Player2_Take_Damage : MonoBehaviour {

	public ParticleSystem blood;
	public int health = 100;
	float maxHealth = 100;
		
	void OnGUI()
	{
		if(health == 0)
			GUI.contentColor = Color.clear;		
		else if(health <= 20)
			GUI.backgroundColor = Color.red;
		else
			GUI.backgroundColor = Color.green;
		
		GUI.HorizontalScrollbar(new Rect (1600,40,200,40), 0, health,100, 0);

	}

	//function to apply damage and add a blood effect when this player has been hit 
	public void RecieveDamage (int amount, Vector3 dir) {

		if(health > 0)
		{
			health -= amount;
			Vector3 position = transform.position;
			
			
			ParticleSystem bloodObj = GameObject.Instantiate (blood, position, Quaternion.LookRotation(dir, Vector3.up)) as ParticleSystem;
			bloodObj.Play();
		}

	}

	//function to handle getting hit by a staple projectile 
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.CompareTag("Staple"))
		{
			RecieveDamage(10, (col.transform.position - transform.position));
			Destroy(col.gameObject);
		}

	}
}
