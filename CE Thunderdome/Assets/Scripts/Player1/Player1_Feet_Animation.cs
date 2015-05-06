using UnityEngine;
using System.Collections;

public class Player1_Feet_Animation : MonoBehaviour {

	private Animator walk;
	private GameObject point;

	float pointX, pointY, playerX, playerY;
	// Use this for initialization
	void Start () {
		walk = GameObject.Find ("P1_Feet").GetComponent<Animator> ();
		point = GameObject.Find ("P1_Projectile_Origin");
	}
	
	// Update is called once per frame
	void Update () {
	
		pointX = point.transform.position.x;
		pointY = point.transform.position.y;
		playerX = gameObject.transform.position.x;
		playerY = gameObject.transform.position.y;


		if((Input.GetAxis("Player1_Left_Xaxis") == 0) && (Input.GetAxis ("Player1_Left_Yaxis") == 0))
			walk.SetInteger("Walking_State", 0);


		if (playerX > pointX) {
			if(Input.GetAxis("Player1_Left_Xaxis") < 0)
				walk.SetInteger("Walking_State", 1);
			else if(Input.GetAxis("Player1_Left_Xaxis") > 0)
				walk.SetInteger("Walking_State", 2);

		}

		else if (playerX < pointX) {
			if(Input.GetAxis("Player1_Left_Xaxis") > 0)
				walk.SetInteger("Walking_State", 1);
			else if(Input.GetAxis("Player1_Left_Xaxis") < 0)
				walk.SetInteger("Walking_State", 2);

		}

		if (Input.GetAxis("Player1_Left_Xaxis") == 0) {
						if (playerY < pointY) {
								if (Input.GetAxis ("Player1_Left_Yaxis") < 0)
										walk.SetInteger ("Walking_State", 1);
								else if (Input.GetAxis ("Player1_Left_Yaxis") > 0)
										walk.SetInteger ("Walking_State", 2);
								
						} else if (playerY > pointY) {
								if (Input.GetAxis ("Player1_Left_Yaxis") > 0)
										walk.SetInteger ("Walking_State", 1);
								else if (Input.GetAxis ("Player1_Left_Yaxis") < 0)
										walk.SetInteger ("Walking_State", 2);
								
						}
				}

	}
}
