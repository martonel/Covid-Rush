using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour,IPointerDownHandler,IEndDragHandler,IDragHandler,IBeginDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        rectTransform.anchoredPosition = new Vector2(0, 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("alma");
        if(other.gameObject.tag == "LittleCovid")
        {
            Debug.Log("getCovid");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("alma2");
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("getCovid2");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("almafa");
    }

}
