using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	//Instance Vairables
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;
	private int numberOfGameObjects;

	//This method gets called upon initialisaiton
	void Start()
	{
		//Upon starting, the count of collected objects is 0. Clear both strings so that they reflect the start of the game
		count = 0;
		SetCountText();
		winText.text = "";

		//Scan the game for objects with the tag 'PickUp'. Count how many there are
		numberOfGameObjects = GameObject.FindGameObjectsWithTag("PickUp").Length;
	}

	//Get the new position from the keys pressed
	void FixedUpdate ()
	{
		//X-Axis & Y-Axis coordinates
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		//Set the new coordinates into a vector
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		//"Push" the player at a set speed in the direction of the vector in the set amount of time
		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
	}

	//This method fires whenever the 'player' collides with a pickup
	void OnTriggerEnter(Collider other) 
	{
		//If the object you collide with has the tag 'PickUp'
		if(other.gameObject.tag == "PickUp")
		{
			//It then no longer becomes an active variable. This will make it disappear.
			other.gameObject.SetActive(false);

			//Increase the amount of collected objects by 1.
			count = count + 1;

			//Refresh the count rate to reflect the addition.
			SetCountText();
		}
	}

	//This method keeps track of how many pickups have been collected
	void SetCountText ()
	{
		//The count text is a string that has 'Count:' as well as the number collected appended to the end.
		countText.text = "Count: " + count.ToString();

		//If the number of collected objects is greater or equal to the number of collectables spawned
		if(count >= numberOfGameObjects)
		{
			//Player has won, let them know by using winText
			winText.text = "You've Won!";
		}
	}
}
//Tushar Iyer