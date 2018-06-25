using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is making sure the player can shoot bullets.
/// </summary>
public class PlayerShoot : MonoBehaviour {
    [SerializeField] private AudioSource _source; //The source variable is an audio source component, this is needed to play a shooting sound when the player shoots.
    [SerializeField] private GameObject _bullet; //The bullet variable is an gameobject which will be spawned the moment the player shoots.
    [SerializeField] private GameObject _nozzle; //The nozzle variable is the position the bullet will be spawned at.


    /// <summary>
    /// In the update function all the methods will be called.
    /// </summary>
    void Update() {
        Aim();
        Flip();
        Shoot();
    }

    /// <summary>
    /// This method is checking for mouse input and when the mouse button is pressed it spawns a bullet and plays a sound.
    /// </summary>
    private void Shoot() {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(_bullet, _nozzle.transform.position, transform.rotation);
            _source.Play();
        }
    }

    /// <summary>
    /// This function makes the player follow the mouse to aim where the bullet will be going.
    /// </summary>
    private void Aim() {
        Vector3 mousePos = MousePosition();
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, transform.rotation.y, angle);
    }

    /// <summary>
    /// This function makes sure that when the player is aiming left the player will be facing left and the other way around as well.
    /// </summary>
    private void Flip() {
        float rotZ = transform.eulerAngles.z;
        if (rotZ >= 90 && rotZ <= 270)
        {
            
            transform.parent.rotation = Quaternion.Euler(transform.parent.rotation.eulerAngles.x, 180, transform.parent.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Euler(-180, 0, -transform.rotation.eulerAngles.z);
        }
        else {
            transform.parent.rotation = Quaternion.Euler(transform.parent.rotation.eulerAngles.x, 0, transform.parent.rotation.eulerAngles.z);
            

        }
        
    }

    /// <summary>
    /// This function calculates the mouse position and then returns it.
    /// </summary>
    private Vector3 MousePosition() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, -10);
        return mousePos;
    }
}
