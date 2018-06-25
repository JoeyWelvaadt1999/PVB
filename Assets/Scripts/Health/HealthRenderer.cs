using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthRenderer : MonoBehaviour {
    [SerializeField] private Image _healthBar;
    private HealthBase _health;
	// Use this for initialization
	void Start () {
        _health = GetComponent<HealthBase>();
	}
	
	// Update is called once per frame
	void Update () {
        _healthBar.fillAmount = (1f / (float)_health.MaxHealth) * (float)_health.GetHealth();
        Debug.Log("Max health:" + _health.MaxHealth);

    }
}
