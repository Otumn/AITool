using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Otumn.Ai;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float speed = 10;
    [SerializeField] private Text countText;
    [SerializeField] private Text winText;
    [SerializeField] private Rigidbody rb;

    private int count = 0;

	void Start ()
	{
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}
}