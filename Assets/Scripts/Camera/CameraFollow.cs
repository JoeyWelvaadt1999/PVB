using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will make sure the camera can follow an object.
/// </summary>
public class CameraFollow : MonoBehaviour {
    [SerializeField] private GameObject _objectToFollow; //This variable indicates the object that has to be followed.
    [SerializeField] private Bounds _cameraBounds;//This variable indicates the maximum and minimum position the camera can move.
	
    /// <summary>
    /// This function moves the camera to the position of the object and keeps it inside the bounds.
    /// </summary>
    void Update() {
        Vector3 tPos = transform.position;

        float height = Camera.main.orthographicSize * 2;
        float width = Camera.main.aspect * height;

        Vector3 objectPos = _objectToFollow.transform.position;

        tPos.x = Mathf.Clamp(transform.position.x, -_cameraBounds.extents.x + (width / 2f), _cameraBounds.extents.x - (width / 2f));
        tPos.y = Mathf.Clamp(transform.position.y, -_cameraBounds.extents.y + (height / 2f), _cameraBounds.extents.y - (height / 2f));
        tPos = Vector3.MoveTowards(tPos, new Vector3(objectPos.x, objectPos.y, tPos.z), 0.5f);
        transform.position = tPos;
    }
}
