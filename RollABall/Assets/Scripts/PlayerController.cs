using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		count = 0;
		// Get a reference to the Player's RigidBody controller
		rb = GetComponent<Rigidbody> ();
		countText.text = "Score: " + count.ToString();
		winText.text = "";
	}

	// Called before performing physics calculations
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
	}

	// Called whenever this object touches another
	void OnTriggerEnter (Collider other)
	{
		// For this to work, must check "Is Trigger" in the Pickup's Box Collider

		// Set a tag in the inspector, under the name.
		if (other.gameObject.CompareTag ("Pickup")) 
		{
			// Deactivate the object
			other.gameObject.SetActive (false);
			count++;
			countText.text = "Score: " + count.ToString();
			if (count == 16)
			{
				winText.text = "You Win!";
			}

			// Add a RigidBody to this, and tick "Is Kinematic", meaning it isn't affected by physics

			// Anything with a collider and a RigidBody is considered Dynamic, 
			// and is more efficient to use for animated objects, such as this.
		}
	}
}
