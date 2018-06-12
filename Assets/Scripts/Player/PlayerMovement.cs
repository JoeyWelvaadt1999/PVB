using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float _movementSpeed;
    private bool _isMoving;

    public bool IsMoving {
        get {
            return _isMoving;
        }
    }

    private Vector3 _newPosition;
    private Vector3 _lastPosition;

    private Dictionary<KeyCode, Vector2> _keyDirections = new Dictionary<KeyCode, Vector2>();

	// Use this for initialization
	void Start () {
        _newPosition = transform.position;
        _lastPosition = transform.position;
        _keyDirections.Add(KeyCode.A, Vector2.left);
        _keyDirections.Add(KeyCode.W, Vector2.up);
        _keyDirections.Add(KeyCode.D, Vector2.right);
        _keyDirections.Add(KeyCode.S, Vector2.down);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        CheckForMovement();
	}

    private void Move() {
        
        KeyCode[] keys = _keyDirections.Keys.ToArray();
        List<Vector2> directions = CollidingDirection();
        if (!_isMoving) {
            for (int i = 0; i < _keyDirections.Keys.Count; i++)
            {
                if (Input.GetKeyDown(keys[i])) {

                    if (!directions.Contains(_keyDirections[keys[i]]))
                    {
                        _newPosition = transform.position;
                        _newPosition.x += _keyDirections[keys[i]].x;
                        _newPosition.y += _keyDirections[keys[i]].y;

                        float angle = Mathf.Atan2(transform.position.y - _newPosition.y, transform.position.x - _newPosition.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle - 180);
                    }
                    
                }
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _newPosition, 0.1f);
    }

    private List<Vector2> CollidingDirection()
    {
        List<Vector2> collidingDirections = new List<Vector2>();

        string layer = "NotWalkable";
        float rayDistance = 0.99f;

        RaycastHit2D[] hitTop = Physics2D.RaycastAll(transform.position, Vector2.up, rayDistance);
        RaycastHit2D[] hitBottom = Physics2D.RaycastAll(transform.position, Vector2.down, rayDistance);
        RaycastHit2D[] hitRight = Physics2D.RaycastAll(transform.position, Vector2.right, rayDistance);
        RaycastHit2D[] hitLeft = Physics2D.RaycastAll(transform.position, Vector2.left, rayDistance);

        RaycastHit2D[][] hits = new RaycastHit2D[4][] { hitTop, hitBottom, hitLeft, hitRight };
        Vector2[] directions = new Vector2[4] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        for (int i = 0; i < hits.Length; i++)
        {
            for (int j = 0; j < hits[i].Length; j++)
            {
                if (hits[i][j].collider.gameObject.layer == LayerMask.NameToLayer(layer))
                {
                    Debug.Log(hits[i][j].collider.tag);
                    collidingDirections.Add(directions[i]);
                }
            }

        }

        return collidingDirections;
    }

    private void CheckForMovement() {
        if (_lastPosition != transform.position)
        {
            _isMoving = true;
            Debug.Log("Moving");
        }
        else {
            _isMoving = false;
        }

        _lastPosition = transform.position;
    }
}
