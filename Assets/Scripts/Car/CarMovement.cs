using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarMovement : MonoBehaviour {
	[SerializeField]private float _accelerationSpeed;
	[SerializeField]private float _rotationSpeed;

	private Rigidbody2D _rb2d;

	private void Start() {
		_rb2d = GetComponent<Rigidbody2D> ();
	}

	private void FixedUpdate() {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		_rb2d.AddForce (y * transform.up * _accelerationSpeed);
		_rb2d.AddTorque (-x * _rotationSpeed);
	}


		
}