using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[Header("-Movement Values-")]
	[SerializeField]
	private float speed;
	[SerializeField]
	private float runMult;
	[SerializeField]
	private float jumpPower;

	private float x;
	private float z;
	private bool grounded;
	private Rigidbody RB;
	private Collider collider;

	void Start () {
		RB = gameObject.GetComponent<Rigidbody> ();
	}

	void Update () {
		grounded = (Physics.Raycast (transform.position, -Vector3.up, + 0.18f));
		x = Input.GetAxis ("Horizontal") * Time.deltaTime * 100.0f * speed;
		z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f * speed;
		if (Input.GetKey("left shift") && z > 0 && grounded) {
			z *= runMult;
		}
		RB.velocity *= .99f;
		transform.Rotate (0, x, 0);
		transform.Translate (0, 0, z);
		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			RB.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
		}
	}
}
