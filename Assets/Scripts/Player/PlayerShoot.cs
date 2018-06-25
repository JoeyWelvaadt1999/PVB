using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [SerializeField] private AudioSource _source;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _nozzle;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Aim();
        Flip();
        Shoot();
    }

    private void Shoot() {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(_bullet, _nozzle.transform.position, transform.rotation);
            _source.Play();
        }
    }

    private void Aim() {
        Vector3 mousePos = MousePosition();
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, transform.rotation.y, angle);
    }

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

    private Vector3 MousePosition() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, -10);
        return mousePos;
    }
}
