using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class moves the bullet
/// </summary>
public class BulletMovement : MonoBehaviour {
    [SerializeField] private float _speed; //The speed variable indicates how fast the bullet is going.
    private float _destroyTime = 5f; //The destroy time variable indicates when the bullet has to be destroyed.
    private float _currentTime; //The current time variable is counting up untill it reaches the same amount as the destroy time variable.
	
	/// <summary>
    /// In the update function the bullet will move in the direction it is facing.
    /// Also the bullet's time is checked.
    /// </summary>
	void Update () {
        Vector2 tPos = transform.position;
        tPos.x += _speed * transform.right.x * Time.deltaTime;
        tPos.y += _speed * transform.right.y * Time.deltaTime;
        transform.position = tPos;


        DestroyBulletAfterTime();
        
	}

    /// <summary>
    /// In this function the current time is being increased and when its bigger or equal to the destroy time this object has to be destroyed.
    /// </summary>
    private void DestroyBulletAfterTime()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _destroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}
