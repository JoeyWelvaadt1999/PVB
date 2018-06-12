using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _nozzle;

    [SerializeField]private float _cooldownTime;
    private float _currentCooldown;

    private void Start()
    {
        _currentCooldown = _cooldownTime;
    }

    // Update is called once per frame
    void Update () {
        if (_currentCooldown >= _cooldownTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(_bullet, _nozzle.transform.position, transform.localRotation);
                _currentCooldown = 0f;
            }
        }

        _currentCooldown += Time.deltaTime;
	}
}
