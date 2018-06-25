using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	[SerializeField]private int _damage;

	public void Attack() {
		PlayerHealth pHealth = FindObjectOfType<PlayerHealth> ();
		pHealth.DecreaseHealth (_damage);
	}
}
