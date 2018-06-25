using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class makes sure the enemy can attack.
/// </summary>
public class EnemyAttack : MonoBehaviour {

	[SerializeField]private int _damage;//This variable indicates the amount of damage the enemy does.

    /// <summary>
    /// This function does damage to the player health.
    /// </summary>
	public void Attack() {
		PlayerHealth pHealth = FindObjectOfType<PlayerHealth> ();
		pHealth.DecreaseHealth (_damage);
	}
}
