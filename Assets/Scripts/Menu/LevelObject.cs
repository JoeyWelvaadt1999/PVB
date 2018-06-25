using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class will show what level it is by showing a canvas when hovering and when clicked on it will go to another scene.
/// </summary>
public class LevelObject : MonoBehaviour {
    [SerializeField] private Canvas _canvas; //The canvas variable contains a few texts and will be shown when the mouse hovers over this object.
    private Bounds _bounds; //The bounds variable will later be used to check if the mouse is inside its bounds.
	

    /// <summary>
    /// The start function initializes the bounds variable.
    /// </summary>
	void Start () {
        _bounds = gameObject.GetComponent<Renderer>().bounds;
    }
	
	/// <summary>
    /// The update function will check whether the mouse enters or not, if so show the canvas object if not dont show it.
    /// </summary>
	void Update () {
        if (HasMouseEntered())
        {
            _canvas.gameObject.SetActive(true);
        }
        else {
            _canvas.gameObject.SetActive(false);
        }
	}

    /// <summary>
    /// This function checks if the mouse is inside the bounds of the object.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// This function calculates the mouse position and then returns it.
    /// </summary>
    private Vector2 MousePosition() {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(worldPos.x, worldPos.y);
    }

    /// <summary>
    /// This function will be called on click and loads another scene.
    /// </summary>
    /// <param name="scene">The scene param is an integer which indicates which scene it has to load.</param>
    public void GoToScene(int scene) {
        SceneManager.LoadScene(scene);
    }
}
