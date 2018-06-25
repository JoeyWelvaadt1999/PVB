using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class will render the health on an image.
/// </summary>
public class HealthRenderer : MonoBehaviour {
    [SerializeField] private Image _healthBar;//The health bar variable will display the health as image.

    private HealthBase _health;//The health variable is used as the health database where the health is stored.
	
    /// <summary>
    /// In the start function the health variable is initialized.
    /// </summary>
	void Start () {
        _health = GetComponent<HealthBase>();
	}
	
	/// <summary>
    /// In the update the fill amount of the health bar image will be calculated constantly.
    /// </summary>
	void Update () {
        _healthBar.fillAmount = (1f / (float)_health.MaxHealth) * (float)_health.GetHealth();
        Debug.Log("Max health:" + _health.MaxHealth);

    }
}
