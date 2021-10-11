using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false; // bool to check if the card is dragging
    private bool isOverDropSonze = false;
    public GameObject dropZone; 
    private Vector2 startPosition; // start of where the card is 


    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y); // if dragging is true, move the card to where the mouse is 
        }
    }

    // when there is a collision between the card and the dropzone 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropSonze = true; // in the drop zone is equal true
        dropZone = collision.gameObject; // dropzone is now equal to dropzone the player is colliding with

        if (collision.gameObject.CompareTag("CompZone"))
        {

            transform.position = startPosition; // set the card back to its original position if in computers zone
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropSonze = false;
        dropZone = null; 
    }

    public void StartDrag()
    {
        startPosition = transform.position; //storing the position where the card started at
        isDragging = true; 
    }

    public void EndDrag()
    {
        isDragging = false;

        if (isOverDropSonze) // if the card is in the dropzone
        {
            transform.SetParent(dropZone.transform, false); // set the card to the parent of the dropzone object
        }
        else // if its not in the dropzone
        {
            transform.position = startPosition; // set the card back to its original position
        }
    }
}
