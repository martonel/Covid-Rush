using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragMask : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler,IPointerDownHandler
{
    //https://www.youtube.com/watch?v=Mb2oua3FjZg
    [SerializeField]
    private RectTransform dragRectTransform;
    [SerializeField]
    private Canvas canvas;

    private Vector3 startPos;
    private Vector3 setPos;
    private bool isEnd = false;
    private bool isFinalEnd = false;
    public MaskCounter counter;
    private GameObject humanFace;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isFinalEnd)
        {
            counter = GameObject.FindGameObjectsWithTag("Mask")[0].GetComponent<MaskCounter>();
            Debug.Log(counter);
            startPos = dragRectTransform.position;
            setPos = dragRectTransform.position;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isFinalEnd)
        {
            dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if(isEnd==true)
        {
            Instantiate(this.gameObject, startPos, Quaternion.identity,this.gameObject.transform.parent);
            if (counter != null)
            {
                counter.SetMaskNumber();
            }
            isFinalEnd = true;
            this.gameObject.transform.SetParent(humanFace.gameObject.transform);
           
        }
        dragRectTransform.position = setPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isFinalEnd)
        {
            dragRectTransform.SetAsLastSibling();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Color shirtColor = other.transform.parent.parent.GetComponent<RandomFaces>().GetColor();
        Color maskColor = this.gameObject.GetComponent<Image>().color;
        if (shirtColor == maskColor)
        {
            humanFace = other.gameObject;
            setPos = other.gameObject.transform.position;
            isEnd = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        setPos =startPos;
        isEnd=false;
    }

}
