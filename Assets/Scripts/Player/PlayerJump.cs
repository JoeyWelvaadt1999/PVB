using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class makes sure the player can jump also it requires the RigidBody2D component because it uses this to calculate the jump.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour {
    [SerializeField] private float _jumpHeight; //The jump height variable is the force at which the jump will go.
    [SerializeField] private GameObject _feetObject; //The feet object variable is used to check if the player is standing on the ground.

    private Rigidbody2D _rb2d; //The rb2d variable will be used to calculate the jump.
	

    /// <summary>
    /// In the start function the rb2d variable is initialized/
    /// </summary>
	void Start () {
        _rb2d = GetComponent<Rigidbody2D>();
	}
	
	/// <summary>
    /// The update is checking for key input and if the player is standing on the ground if so it can call the jump method.
    /// </summary>
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            Jump();
        }
	}

    /// <summary>
    /// The jump method creates a force and then applies it to the rb2d.
    /// </summary>
    private void Jump() {
        Vector2 force = new Vector2(transform.position.x, _jumpHeight);
        _rb2d.AddForce(force, ForceMode2D.Force);
    }

    /// <summary>
    /// In the isgrounded method its checking if the player is standing on a solid ground by casting a ray downwards.
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded() {
        RaycastHit2D hit2d = Physics2D.Raycast(_feetObject.transform.position, Vector2.down, 1f);

        if (hit2d.collider.tag == "Floor") {
            return true;
        }

        return false;
    }
}
