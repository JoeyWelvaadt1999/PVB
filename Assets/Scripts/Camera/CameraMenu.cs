using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour {
    [SerializeField] private float _minZoom;
    [SerializeField] private float _maxZoom;
    [SerializeField] private float _zoomMultiplier;

    [SerializeField] private float _movementSpeed;

    private Vector2 _zoom;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ZoomCamera();
        MoveCamera();
	}

    private void MoveCamera() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 tPos = transform.position;
        tPos.x += x * _movementSpeed * Time.deltaTime;
        tPos.y += y * _movementSpeed * Time.deltaTime;
        transform.position = tPos;
    }

    private void ZoomCamera() {
        if (Input.mouseScrollDelta.y != 0)
        {
            _zoom = Input.mouseScrollDelta * _zoomMultiplier;
        }
        else {
            _zoom = Vector2.Lerp(_zoom, Vector2.zero, 0.1f);
        }
        
       
       Camera.main.orthographicSize = Mathf.SmoothStep(Camera.main.orthographicSize, Camera.main.orthographicSize + _zoom.y, 1f);
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, _minZoom, _maxZoom);
    }
    
}
