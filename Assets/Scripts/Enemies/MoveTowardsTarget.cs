using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will make the object move towards a target.
/// </summary>
public class MoveTowardsTarget : MonoBehaviour {
	[SerializeField]private float _speed; //The speed variable indicates in what speed the object will be moving.
	[SerializeField]private float _range; //The range variable indicates in when the object is close enough to the target.
	private GameObject _target; //The target variable is the gameobject that this object will be moving towards.

	private EnemyAttack _attack;//The attack variable is later used to attack the target.

	private float _cooldown;//The cooldown variable indicates how long the object has to wait between attacks.


    /// <summary>
    /// In the start function the attack and the target variable are initialized.
    /// </summary>
	private void Start() {
		_attack = GetComponent<EnemyAttack> ();
        _target = FindObjectOfType<PlayerMovement>().gameObject;

	}

	/// <summary>
    /// This function will call the inrange function.
    /// </summary>
	void Update ()
    {
		InRange ();
	}

    /// <summary>
    /// In this function the movement direction is calculated and returned.
    /// </summary>
	private Vector2 GetMovementDirection() {
		Vector3 direction = _target.transform.position - transform.position;

		return direction.normalized;
	}


    /// <summary>
    /// This function will check if the object is inrange of the target, if so attack the target, if not walk towards the target.
    /// </summary>
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
