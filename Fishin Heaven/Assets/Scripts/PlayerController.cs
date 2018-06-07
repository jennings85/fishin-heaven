using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[Header("-Movement Values-")]
	[SerializeField]
	private float speed;
	[SerializeField]
	private int energy = 100;
	[SerializeField]
	private float runMult;
	[SerializeField]
	private float jumpPower;

	private float x;
	private float z;
	private float groundDist;
	private Rigidbody RB;
	private Collider collider;
	private float distToGround;
	public Text energyText;
	public Image energyPic;

	void Start () {
		RB = gameObject.GetComponent<Rigidbody> ();
		collider = gameObject.GetComponent<CapsuleCollider> ();
		distToGround = collider.bounds.extents.y;
	}

	void Update () {
		energyText.text = "Energy: " + energy;
		energyPic.rectTransform.sizeDelta = new Vector2 (energy * 3, 50);
		x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f * speed;
		z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f * speed;
		if (Input.GetKey("left shift") && energy > 3 && z > 0) {
			z *= runMult;
			energy -= 3;
		}
		RB.velocity *= .99f;
		transform.Rotate (0, x, 0);
		transform.Translate (0, 0, z);
		if (Input.GetKeyDown(KeyCode.Space) && (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0f)) && energy == 100){
			RB.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
			energy = 0;
		}
		if (energy == 99) {
			energy = 100;
		} else if (energy < 99) {
			energy += 2;
		}
	}
}
