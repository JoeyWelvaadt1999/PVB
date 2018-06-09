using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public enum EnemyStates {
    Walking,
    Spotting,
    Seeking
}

public class Computer : MonoBehaviour {
    private StateMachine<EnemyStates> _stateMachine = new StateMachine<EnemyStates>();
    public StateMachine<EnemyStates> States {
        get {
            return _stateMachine;
        }
    }
	// Use this for initialization
	void Start () {
        _stateMachine.AddState(EnemyStates.Walking, GetComponent<WalkingState>());
        _stateMachine.AddState(EnemyStates.Spotting, GetComponent<SpottingState>());
        _stateMachine.AddState(EnemyStates.Seeking, GetComponent<SeekingState>());

        _stateMachine.SetState(EnemyStates.Walking);
    }
	
	// Update is called once per frame
	void Update () {
        _stateMachine.Update();
	}
}
