using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used for the enemies health and gets most of its functionality from its inheritance.
/// </summary>
public class EnemyHealth : HealthBase {
    [SerializeField] private Animator _anim; //The anim variable is used to play animations.
    [SerializeField] private Renderer _renderer; //The render variable is later used to change the objects color.

	
	/// <summary>
    /// The update function constantly calls the check health function.
    /// </summary>
	void Update () {
        CheckHealth();
	}

    /// <summary>
    /// The check health function checks if the health of the enemy is below zero if so,
    /// the anim will set a boolean called died to true and a animation will play, if 
    /// this animations is done playing the object will be destroyed.
    /// </summary>
    public void CheckHealth() {
        if (_health <= 0) {
            
            
            _anim.SetBool("Died", true);
            
            
            if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Death") && !_anim.GetCurrentAnimatorStateInfo(0).IsName("Walk") && _anim.GetBool("Died")) {
                Destroy(this.gameObject);
            }
            

        }
    }

    /// <summary>
    /// This function will check if a object with a collider enters if this collider has a tag named bullet it will do damage and also start a coroutine.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet") 
        {
            _health -= 10;
            Destroy(collision.gameObject);
            StartCoroutine(FlashDamage());
        }
    }

    /// <summary>
    /// This function changes the objects color for a split second to show the player that he enemy took damage.
    /// </summary>
    private IEnumerator FlashDamage() {

        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = Color.white;
    }
}
