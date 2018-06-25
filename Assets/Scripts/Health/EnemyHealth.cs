using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBase {
    [SerializeField] private Animator _anim;
    [SerializeField] private Renderer _renderer;

	
	// Update is called once per frame
	void Update () {
        CheckHealth();
	}

    public void CheckHealth() {
        if (_health <= 0) {
            
            
            _anim.SetBool("Died", true);
            
            
            if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Death") && !_anim.GetCurrentAnimatorStateInfo(0).IsName("Walk") && _anim.GetBool("Died")) {
                Destroy(this.gameObject);
            }
            

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet") 
        {
            _health -= 10;
            Destroy(collision.gameObject);
            StartCoroutine(FlashDamage());
        }
    }

    private IEnumerator FlashDamage() {

        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.white;
    }
}
