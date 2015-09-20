using UnityEngine;
using System.Collections;


//este script vai ficar "attached" ao background to MainMenu
public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckForTouch();
	}

    void CheckForTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if(touch.phase == TouchPhase.Began)
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 touchPosition = new Vector2(worldPoint.x, worldPoint.y);

                Collider2D touchedAnything = Physics2D.OverlapPoint(touchPosition);

                if (touchedAnything)
                {
                    Debug.Log("You pressed" + touchedAnything.tag);
                }
            }
        }
    }
}
