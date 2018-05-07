using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private GameObject _wheels;

    private float _rotationAngle;

    private Vector2 _oldPostion;
    private Vector2 _currentPostion;
    // Update is called once per frame
    void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        SetRotation(x, y);

        Move(y);
        
	}

    private void SetRotation(float x , float y) {
        Quaternion wheelRot = _wheels.transform.rotation;


        

        if (y != 0) 
        {
            _rotationAngle += (-x) * _rotationSpeed * Time.deltaTime;
            _wheels.transform.localEulerAngles = new Vector3(0, 0, _rotationAngle);
            float angle = Mathf.LerpAngle(transform.localEulerAngles.z, transform.localEulerAngles.z + _wheels.transform.localEulerAngles.z, 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
         
        
    }

    private void Move(float y) {
        _currentPostion = transform.position;
        Vector2 pos = transform.position;
        pos.x += (_movementSpeed * y * transform.up.x) * Time.deltaTime;
        pos.y += (_movementSpeed * y * transform.up.y) * Time.deltaTime;
        transform.position = pos;
        _oldPostion = transform.position;
    }
}
