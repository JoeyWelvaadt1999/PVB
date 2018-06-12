using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using System;

public class SpottingState : State {
    public override void Act()

    { 
        Collider2D col = Physics2D.OverlapCircle(transform.position, 3.5f, LayerMask.GetMask("Player"));
        GameObject go = col.gameObject;
        Destroy(go);
        StartCoroutine(GoToMenu());
    }

    public override void Reason()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator GoToMenu() {
        yield return new WaitForSeconds(3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
