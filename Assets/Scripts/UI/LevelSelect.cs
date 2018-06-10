using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
	[SerializeField]private GameObject _levelSelect;
	// Use this for initialization
	void Start () {
		_levelSelect.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenLevelSelect(bool open) {
		_levelSelect.SetActive (open);
	}

	public void SelectLevel(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
