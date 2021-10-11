using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    private GameObject Canvas;

    private GameObject zoomCard;

    public float newXSize = 0;
    public float newYSize = 0;

    public void Awake()
    {
        Canvas = GameObject.Find("Canvas"); 
    }

    public void OnHoverEnter()
    {
        // on hover instantiate the game object to a new position where the mouse is
        zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 120), Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, true);
        zoomCard.layer = LayerMask.NameToLayer("Zoom"); 

        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(newXSize, newYSize);
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard); 
    }
}
