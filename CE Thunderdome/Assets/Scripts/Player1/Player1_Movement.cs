using UnityEngine;
using System.Collections;

public class Player1_Movement : MonoBehaviour {
	
	public float speed;
	float deadzone;
	Vector3 turn;
	void Start () 
	{
		turn = new Vector3();
		deadzone = 0.25f;
		
	}
	
	void Update () {
		Vector3 vel = new Vector3();
		
		if(Input.GetAxis("Player1_Left_Yaxis") < 0){ //If left stick is pressed up, move player up
			Debug.Log("Player1 Up");
			Vector3 velUp = new Vector3();
			velUp.y = 1;
			vel += velUp;
		}
		
		else if(Input.GetAxis("Player1_Left_Yaxis") > 0){ //If left stick is pressed down, move player down
			Debug.Log("Player1 Down");
			Vector3 velDown = new Vector3();
			velDown.y = -1;
			vel += velDown;
		}
		else{											//if neither, player's vertical position will not move
			Vector3 velStop = rigidbody2D.velocity;
			velStop.y = 0;
			rigidbody2D.velocity = velStop;
		}
		
		
		// no else here. Combinations of up/down and left/right are fine.
		if(Input.GetAxis("Player1_Left_Xaxis") < 0){ //If left stick is pressed left, move player left
			Debug.Log("Player1 Left");
			Vector3 velLeft = new Vector3();
			velLeft.x = -1;
			vel += velLeft;
		}
		
		else if(Input.GetAxis("Player1_Left_Xaxis") > 0){ //If left stick is pressed right, move player right
			Debug.Log("Player1 Right");
			Vector3 velRight = new Vector3();
			velRight.x = 1;
			vel += velRight;
		}
		
		else{											//if neither, player's horizontal position will not move
			Vector3 velStop = rigidbody2D.velocity;
			velStop.x = 0;
			rigidbody2D.velocity = velStop;
		}
		
		if(Input.GetButtonDown("Player1_Pickup")){
			Debug.Log("Player1 A");
		}

		if(Input.GetButtonDown("Player1_Attack")){
			Debug.Log("Player1 RB");
		}
		
		//apply velocity to player based on directional input
		if (vel.magnitude > 0.001) {
			Vector3.Normalize(vel);
			vel *= speed;
			rigidbody2D.velocity = vel;
		}
		
		//get rotation based on right stick 		
		turn.x = -Input.GetAxis ("Player1_Right_Xaxis");
		turn.y = -Input.GetAxis ("Player1_Right_Yaxis");
		
		//apply rotation if outside of stick deadzone 
		if(turn.sqrMagnitude > deadzone) {
			float angle = Mathf.Atan2 (turn.x, turn.y) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
		}
		

	}
}