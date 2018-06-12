using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _plateObjects;
    private int _plates;
	// Use this for initialization
	void Start () {
        _plates = PlayerPrefs.GetInt("Plates");
        for (int i = 0; i < _plates; i++)
        {
            Instantiate(_plateObjects[i], _spawnPoints[i].position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
