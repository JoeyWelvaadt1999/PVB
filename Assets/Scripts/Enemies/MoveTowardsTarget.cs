using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour {
	[SerializeField]private float _speed;
	[SerializeField]private float _range; 
	private GameObject _target;

	private EnemyAttack _attack;

	private float _cooldown;

	private void Start() {
		_attack = GetComponent<EnemyAttack> ();
        _target = FindObjectOfType<PlayerMovement>().gameObject;

	}

	// Update is called once per frame
	void Update ()
    {
		InRange ();
	}

	private Vector2 GetMovementDirection() {
		Vector3 direction = _target.transform.position - transform.position;

		return direction.normalized;
	}

	private void InRange() {
		float distance = (_target.transform.position - transform.position).magnitude;
		if (distance < _range) {
			if (_cooldown == 0) {
				_attack.Attack ();
				_cooldown = 5f;
			}
		} else {
			Vector2 direction = GetMovementDirection ();
			Vector2 tPos = transform.position;
			tPos.x += direction.x * _speed * Time.deltaTime;
			transform.position = tPos;
		}	
		if (_cooldown > 0f) {
			_cooldown -= Time.deltaTime;
		} else {
			_cooldown = 0f;
		}
	} 
}
