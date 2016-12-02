using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
	//No instance variables required in this class.

	//Update the rotation of the PickUps every frame
	void Update () 
	{
		//PickUp's new position is the old position + the new vector
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
//Tushar Iyer