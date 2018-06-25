using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthBase {
    void Update()
    {
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (_health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die() {
        Destroy(this.gameObject);
        Time.timeScale = 0;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
