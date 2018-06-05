using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField]private GameObject _objectToFollow;

	void Update () {
		Vector3 tPos = transform.position;
		tPos = Vector3.Lerp (tPos, new Vector3(_objectToFollow.transform.position.x, _objectToFollow.transform.position.y, tPos.z), 0.5f);
		transform.position = tPos;
	}
}
