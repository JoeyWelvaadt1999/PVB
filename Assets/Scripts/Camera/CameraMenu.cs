using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class will move the camera around in the menu.
/// </summary>
public class CameraMenu : MonoBehaviour {
    [SerializeField] private float _minZoom;//This variable indicates the minimum zoom value the camera can go.
    [SerializeField] private float _maxZoom;//This variable indicates the maximum zoom value the camera can go.
    [SerializeField] private float _zoomMultiplier;//This variable indicates how fast the camera will zoom.

    [SerializeField] private float _movementSpeed;//This is the speed at which the camera will move around.

    private Vector2 _zoom;//This variable contains the current zoom value.
	
	
	/// <summary>
    /// This function calls the zoom and move camera functions.
    /// </summary>
	void Update () {
        ZoomCamera();
        MoveCamera();
	}

    /// <summary>
    /// This function will move around the camera by multiplying the horizontal axis by the movement speed for the x axis and
    /// multiplying the vertical axis by the movement speed for the y axis.
    /// </summary>
    private void MoveCamera() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 tPos = transform.position;
        tPos.x += x * _movementSpeed * Time.deltaTime;
        tPos.y += y * _movementSpeed * Time.deltaTime;
        transform.position = tPos;
    }

    /// <summary>
    /// This function will zoom the camera in and out using the scrollwheel.
    /// </summary>
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
