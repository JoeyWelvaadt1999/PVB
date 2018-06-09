using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float _movementSpeed;
    private bool _isMoving;

    public bool IsMoving {
        get {
            return _isMoving;
        }
    }

    private Vector3 _lastPosition;

	// Use this for initialization
	void Start () {
        _lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        CheckForMovement();
	}

    private void Move() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 tPos = transform.position;
        tPos.x += (x * _movementSpeed) * Time.deltaTime;
        tPos.y += (y * _movementSpeed) * Time.deltaTime;
        transform.position = tPos;
    }

    private void CheckForMovement() {
        if (_lastPosition != transform.position)
        {
            _isMoving = true;
        }
        else {
            _isMoving = false;
        }

        _lastPosition = transform.position;
    }
}
