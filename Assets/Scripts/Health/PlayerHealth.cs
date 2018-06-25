using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class indicates the player health and get most of its functionality from its inheritance.
/// </summary>
public class PlayerHealth : HealthBase {

    /// <summary>
    /// In the update function the checkhealth function is constantly being called.
    /// </summary>
    void Update()
    {
        CheckHealth();
    }

    /// <summary>
    /// The checkhealth function checks if the player health is below zero if so start a coroutine.
    /// </summary>
    public void CheckHealth()
    {
        if (_health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    /// <summary>
    /// In this function the object is being destroyed and another scene is being loaded.
    /// </summary>
    private IEnumerator Die() {
        Destroy(this.gameObject);
        Time.timeScale = 0;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
