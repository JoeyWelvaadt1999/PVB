using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {
    private string[] _collidingTags = new string[2] { "Building", "Enemy" };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < _collidingTags.Length; i++)
        {
            if (collision.gameObject.tag == _collidingTags[i]) {
                Destroy(this.gameObject);
            }
        }
    }
}
