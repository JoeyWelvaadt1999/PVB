using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObject : MonoBehaviour {
    [SerializeField] private Canvas _canvas;
    private Bounds _bounds;
	// Use this for initialization
	void Start () {
        _bounds = gameObject.GetComponent<Renderer>().bounds;
    }
	
	// Update is called once per frame
	void Update () {
        if (HasMouseEntered())
        {
            _canvas.gameObject.SetActive(true);
        }
        else {
            _canvas.gameObject.SetActive(false);
        }
	}

    private bool HasMouseEntered() {
        Vector2 mousePos = MousePosition();
        if(mousePos.x < _bounds.center.x + (_bounds.extents.x) && mousePos.x > _bounds.center.x - (_bounds.extents.x))
        {
            if (mousePos.y < _bounds.center.y + (_bounds.extents.y) && mousePos.y > _bounds.center.y - (_bounds.extents.y)) {
                return true;
            }
        }
        return false;        
    }

    private Vector2 MousePosition() {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(worldPos.x, worldPos.y);
    }

    public void GoToScene(int scene) {
        SceneManager.LoadScene(scene);
    }
}
