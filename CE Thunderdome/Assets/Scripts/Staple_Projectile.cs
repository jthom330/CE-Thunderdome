using UnityEngine;
using System.Collections;

public class Staple_Projectile : MonoBehaviour 
{
	
	private float moveSpeed = 10f; // how fast the bullet moves
	private float timeSpentAlive; // how long the bullet has stayed alive for

	

	void Update () 
	{
		timeSpentAlive += Time.deltaTime;
		
		if (timeSpentAlive > 1) // if we have been traveling for more than one second remove the projectile
		{
			removeMe();
		}
		
		// move the projectile 
		transform.Translate(moveSpeed * Time.deltaTime, 0,0);
		transform.position = new Vector3(transform.position.x, transform.position.y,0); // because the projectile has a rigid body we don't want it moving off it's Y axis
	}
	
	void removeMe()
	{
		Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log ("Hit!");
		if(col.gameObject.tag == "Wall")
		{
			Destroy(gameObject);
		}
		
	}
	

}