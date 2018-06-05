using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedRenderer : MonoBehaviour {
	[SerializeField] private Image _speedImage;
	private CarMovement _movement;
	// Use this for initialization
	void Start () {
		_movement = FindObjectOfType<CarMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
//		float speed = _movement.Velocity.magnitude;
//		_speedImage.fillAmount = (1f / 45f) * speed;
	}
}
