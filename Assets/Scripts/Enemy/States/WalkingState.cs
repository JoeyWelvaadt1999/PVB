using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class WalkingState : State {
    [SerializeField] private Transform[] _path;
    private Computer _computer;

    private int _nextIndex = 1;
    private int _currentIndex = 1;

    private bool _reverse;

    private void Start () {
        _computer = GetComponent<Computer>();
        transform.position = _path[0].position;
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

    public override void Act()
    {
        FollowPath();
    }

    public override void Reason()
    {
        if (_currentIndex == _path.Length - 1 && transform.position == _path[_currentIndex].position)
        {
            _currentIndex = _nextIndex;
            _computer.States.SetState(EnemyStates.Seeking);
        }
        else if (_currentIndex == 0 && transform.position == _path[_currentIndex].position) {
            _currentIndex = _nextIndex;
            _computer.States.SetState(EnemyStates.Seeking);
        }
    }

    private void FollowPath() {
        transform.position = Vector2.MoveTowards(transform.position, _path[_nextIndex].position , 5f * Time.deltaTime);
        if (transform.position == _path[_nextIndex].position) {
            _currentIndex = _nextIndex;
            if (!_reverse)
            {
                if (_nextIndex == _path.Length - 1)
                {
                    _nextIndex -= 1;
                    _reverse = true;
                }
                else
                {
                    _nextIndex += 1;
                }
            }
            else {
                if (_nextIndex == 0)
                {
                    _nextIndex += 1;
                    _reverse = false;
                }
                else {
                    _nextIndex -= 1;
                }
            }
        }
    }
}
