using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 

{
	//Instance variables
	public GameObject player;
	private Vector3 offset;

	//This method gets called upon initialisaiton
	void Start () {
		//The offset vector is now set to the default position
		offset = transform.position;
	}
	
	//This method gets called whenever the frame refreshes
	void LateUpdate () {
		//Set the player's position to the previous position + coordinates of transform.
		transform.position = player.transform.position + offset;
	}
}
//Tushar Iyer