using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    // Variables 
    public GameObject Canvas;
    private bool isDragging = false; // bool to check if the card is dragging
    private bool isOverDropSonze = false;
    public GameObject dropZone;
    private GameObject startParent; 
    private Vector2 startPosition; // start of where the card is 
    public AudioSource wrongAreaSound; // error sound 
    

    private void Awake()
    {
        Canvas = GameObject.Find("Main Canvas"); // find the canvas in the scene 
    }

    void Update()
    {
        if (isDragging) // if the card is being dragged
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //  move the card to where the mouse is
            transform.SetParent(Canvas.transform, true); // set the card to a child of the canvas
        }
    }

    // when there is a collision between the card and the dropzone 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropSonze = true; // in the drop zone is equal true
        dropZone = collision.gameObject; // dropzone is now equal to dropzone the player is colliding with
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropSonze = false;
        dropZone = null;
    }

    public void StartDrag() // when player starts to drag
    {
        startParent = transform.parent.gameObject; //storing the parent element where the card started at
        startPosition = transform.position; //storing the position where the card started at
        isDragging = true; 
    }

    public void EndDrag() // when the player stops holding the card they are dragging
    {
        isDragging = false;

        if (isOverDropSonze) // if the card is in the dropzone
        {
            transform.SetParent(dropZone.transform, false); // set the card to the parent of the dropzone object
        }
        else // if its not in the dropzone
        {
            transform.position = startPosition; // set the card back to its original position
            transform.SetParent(startParent.transform, false);
            wrongAreaSound.Play(); 
        }
    }
}
