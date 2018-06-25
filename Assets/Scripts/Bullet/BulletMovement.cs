using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    [SerializeField] private float _speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 tPos = transform.position;
        tPos.x += _speed * transform.right.x * Time.deltaTime;
        tPos.y += _speed * transform.right.y * Time.deltaTime;
        transform.position = tPos;
        Debug.Log(transform.up);
	}
}
