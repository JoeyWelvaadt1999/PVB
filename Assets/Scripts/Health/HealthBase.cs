using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour {
	[SerializeField]protected int _health;
    private int _maxHealth;

    public int MaxHealth {
        get {
            return _maxHealth;
        }
    }

    private void Start()
    {
        _maxHealth = _health;
    }

    public void DecreaseHealth(int amount) {
		_health -= amount;

	}

	public int GetHealth() {
		return _health;
	}
}
