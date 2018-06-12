using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {
    private Vector2 _worldPosition;

    public Node(Vector2 worldPosition) {
        _worldPosition = worldPosition;
    }

    public Vector2 WorldPosition {
        get {
            return _worldPosition;
        }
    }
}