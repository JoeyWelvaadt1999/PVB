using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private List<GameObject> _enemies = new List<GameObject>();
	// Use this for initialization
	void Start () {
        Computer[] enemies = FindObjectsOfType<Computer>();
        for (int i = 0; i < enemies.Length; i++)
        {
            _enemies.Add(enemies[i].gameObject);
        }
	}

    private void Update()
    {
        if (_enemies.Count == 0) {
            PlayerPrefs.SetInt("Plates", 1);
            SceneManager.LoadScene(0);
        }
    }

    public void RemoveEnemy(GameObject go) {
        if (_enemies.Contains(go)) {
            _enemies.Remove(go);
        }
    }
}
