using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class SeekingState : State {
    [SerializeField] private float _seekingTime;
    [SerializeField] private float _seekingRadius;
    private Computer _computer;

    // Use this for initialization
    void Start () {
        _computer = GetComponent<Computer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Leave()
    {
        base.Leave();
        StopAllCoroutines();
    }

    public override void Act()
    {
        StartCoroutine(WaitToReturn());
        
    }

    public override void Reason()
    {
        CheckForPlayer();
    }

    private void CheckForPlayer() {
        Collider2D col = Physics2D.OverlapCircle(transform.position, _seekingRadius, LayerMask.GetMask("Player"));
        if (col != null)
        {
            PlayerMovement pm = col.GetComponent<PlayerMovement>();
            if (pm.IsMoving) {
                _computer.States.SetState(EnemyStates.Spotting);
            }
        }
    }

    private IEnumerator WaitToReturn() {
        yield return new WaitForSeconds(_seekingTime);
        _computer.States.SetState(EnemyStates.Walking);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _seekingRadius);
    }
}
