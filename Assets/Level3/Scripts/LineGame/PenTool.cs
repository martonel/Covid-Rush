using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenTool : MonoBehaviour
{
    [Header("Dots")]
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private Transform dotParent;


    [Header("Lines")]
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private Transform lineParent;

    public GameObject dot;
    
    private LineController currentLine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(currentLine == null)
            {
                currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineController>();
            }

            dot = Instantiate(dotPrefab, GetMousePosition(), Quaternion.identity, dotParent);
           // currentLine.AddPoint(dot.transform);
        }
    }


    private Vector3 GetMousePosition()
    {
        Vector3 worldMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        worldMousePos.z = 0;
        return worldMousePos;
    }
}
