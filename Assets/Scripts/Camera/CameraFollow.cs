using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] private GameObject _objectToFollow;
    [SerializeField] private Bounds _cameraBounds;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
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
