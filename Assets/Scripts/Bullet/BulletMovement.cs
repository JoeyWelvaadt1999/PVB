using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    [SerializeField] private float _movementSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 tPos = transform.position;
        tPos.x += transform.right.x * _movementSpeed * Time.deltaTime;
        tPos.y += transform.right.y * _movementSpeed * Time.deltaTime;
        transform.position = tPos;
    }
}
