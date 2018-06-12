using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
    private LevelManager _lm;
    private string _colliderTag = "Bullet";

    private void Start()
    {
        _lm = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == _colliderTag) {
            _lm.RemoveEnemy(this.gameObject);
            Destroy(this.gameObject);
            
        }
    }
}
