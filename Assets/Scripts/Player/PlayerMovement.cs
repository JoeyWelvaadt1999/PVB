
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will make the player move
/// </summary>
public class PlayerMovement : MonoBehaviour { 

    [SerializeField] private float _speed;//The speed variable indicates how fast the player will move around.


    /// <summary>
    /// In the update function the player is moving left and right by multiplying the input by the speed.
    /// </summary>
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 tPos = transform.position;
        tPos.x += (_speed * x) * Time.deltaTime;
        transform.position = tPos;
    }
}