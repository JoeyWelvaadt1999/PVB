using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    [SerializeField] private Transform[] _spawnLocations;
    [SerializeField] private GameObject _enemyObject;
    [SerializeField] private float _spawnDelay;

    private float _countDown;

	
	void Update () {
        _countDown += Time.deltaTime;
        if (_countDown >= _spawnDelay) {
            int spawnIndex = Random.Range(0, _spawnLocations.Length);

            Instantiate(_enemyObject, _spawnLocations[spawnIndex].position, Quaternion.identity);

            _countDown = 0;
        }

        if (_spawnDelay > 1f) {
            _spawnDelay -= 1f/10000f;
        }
	}
}
