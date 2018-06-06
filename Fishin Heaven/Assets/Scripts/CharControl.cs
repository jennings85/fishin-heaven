using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharControl : MonoBehaviour {
	private float speed = 3.0f;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
		if (Input.GetKey ("left shift")) {
			speed = 4.0f;
		} else {
			speed = 3.0f;
		}
		if (Input.GetKey ("space")) {
			gameObject.GetComponent<Rigidbody> ().AddForce (0, 15, 0);
		}
		float translation = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float straffe = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;

		transform.Translate (straffe, 0, translation);
	}
}
