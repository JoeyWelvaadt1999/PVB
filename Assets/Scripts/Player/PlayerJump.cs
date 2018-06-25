using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour {
    [SerializeField] private float _jumpHeight;
    [SerializeField] private GameObject _feetObject;

    private Rigidbody2D _rb2d;
	// Use this for initialization
	void Start () {
        _rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            Jump();
        }
	}

    private void Jump() {
        Vector2 force = new Vector2(transform.position.x, _jumpHeight);
        _rb2d.AddForce(force, ForceMode2D.Force);
    }

    private bool IsGrounded() {
        RaycastHit2D hit2d = Physics2D.Raycast(_feetObject.transform.position, Vector2.down, 1f);

        if (hit2d.collider.tag == "Floor") {
            return true;
        }

        return false;
    }
}
