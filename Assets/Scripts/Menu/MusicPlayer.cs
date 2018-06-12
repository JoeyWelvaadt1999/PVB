using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    [SerializeField] private AudioClip _clip;
    private AudioSource _source;
	// Use this for initialization
	void Start () {
        GameObject go = GameObject.FindGameObjectWithTag("MusicPlayer");
        _source = go.GetComponent<AudioSource>();

	}
    private void OnMouseDown()
    {
        _source.clip = _clip;
        _source.Play();
    }
}
