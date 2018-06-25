using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In this class enemies will be spawned on different locations.
/// </summary>
public class SpawnEnemies : MonoBehaviour {
    [SerializeField] private Transform[] _spawnLocations; //The spawn locations variable is an array of different spawn locations.
    [SerializeField] private GameObject _enemyObject; //The enemy object variable is the object that will be spawned.
    [SerializeField] private float _spawnDelay; //The spawn delay variable is the amount of time the class has to wait to spawn a new enemy.

    private float _countDown;//The count down variable is counting untill it is equal to the spawn delay variable.

	/// <summary>
    /// In the update function the count down variable is going up untill it is equal to the spawn delay, 
    /// if so a random int between 0 and the length of the spawn locations array will be chosen and then a
    /// enemy will be spawned on that location.
    /// Also the spawn delay is slowly going down to speed up the spawning of enemies.
    /// </summary>
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
