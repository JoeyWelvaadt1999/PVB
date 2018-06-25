using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The health base class will be inherated by other health classes to get basic health functionality.
/// </summary>
public class HealthBase : MonoBehaviour {
	[SerializeField]protected int _health;//The health variable is the current health the object has.
    private int _maxHealth; //The max health variable is the max health the object has.

    //The MaxHealth getter is used by other classes to get the max health variable.
    public int MaxHealth {
        get {
            return _maxHealth;
        }
    }

    /// <summary>
    /// In the start function the max health is set to the same amount as health.
    /// </summary>
    private void Start()
    {
        _maxHealth = _health;
    }

    /// <summary>
    /// In this function the health is being decreased by a certain amount.
    /// </summary>
    /// <param name="amount">The amount parameter indicates at which value the health has to be decreased.</param>
    public void DecreaseHealth(int amount) {
		_health -= amount;

	}

    /// <summary>
    /// This function is used by other classes to get the health variable.
    /// </summary>

	public int GetHealth() {
		return _health;
	}
}
