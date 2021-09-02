using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{

    private LineRenderer lr;
    public Vector3 mousePos;

    private int number;
    private int startNumber;
    [SerializeField] private GameObject[] points;
    [SerializeField] private Canvas myCanvas;
    [SerializeField] private Canvas bgCanvas;
    public Vector3 screenPointPos;
    private GameObject cam;
    public float dist;

    private bool overBool;

    private TimeCounter counter;
    private float TimerMinusNumber = 300.0f;
    private Animator anim;


    private Vector3 mPosZ; 
    private Vector3 firstPostZ;


    private PlayerMovement2D player;
    void Start()
    {
        cam = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        myCanvas.worldCamera = cam.GetComponent<Camera>();
        bgCanvas.worldCamera = cam.GetComponent<Camera>();
        anim =this.gameObject.transform.parent.gameObject.GetComponent<Animator>();
        counter = GameObject.FindGameObjectsWithTag("Timer")[0].GetComponent<TimeCounter>();
        overBool = false;
        dist = 10.0f;
        startNumber = 0;
        number = points.Length;
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        screenPointPos = new Vector3(points[1].transform.position.x, points[1].transform.position.y, 0.0f);
        Debug.Log(screenPointPos);

        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement2D>();
        player.SetMove(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!overBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (dist <= 0.7f)
                {
                    lr.positionCount++;
                }
            }
            if (Input.GetMouseButton(0))
            {
                mousePos = GetMousePosInCanvas();
                lr.SetPosition(startNumber, points[startNumber].transform.position);
                lr.SetPosition(startNumber + 1, mousePos);
                mPosZ = new Vector3(mousePos.x, mousePos.y, 0f);
                firstPostZ = new Vector3(points[startNumber+1].transform.position.x, points[startNumber+1].transform.position.y, 0);
                dist = Vector3.Distance(mPosZ, firstPostZ);

            }
            if (Input.GetMouseButtonUp(0))
            {
                if (dist <= 0.7f)
                {
                    mousePos = points[startNumber + 1].transform.position;
                    lr.SetPosition(startNumber + 1, mousePos);
                    NextPoint();
                }
                else
                {
                    lr.SetPosition(startNumber+1, points[startNumber].transform.position);
                }

            }
        }
    }

    public void NextPoint()
    {
        if (number-2 > startNumber)
        {
            startNumber++;
            screenPointPos = new Vector3(points[startNumber+1].transform.position.x, points[startNumber+1].transform.position.y, 0.0f);
            Debug.Log(number + " " + startNumber);
        }
        else
        {
            overBool = true;
            Debug.Log("Minigame over");
            counter.SetTimmer(TimerMinusNumber);
            Invoke("End", 2.5f);
            anim.Play("End");
        }
    }


    //https://answers.unity.com/questions/849117/46-ui-image-follow-mouse-position.html
    public Vector3 GetMousePosInCanvas()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        return myCanvas.transform.TransformPoint(pos);
    }

    private void End()
    {
        player.SetMove(true);
        GameObject parent = this.gameObject.transform.parent.gameObject;
        Destroy(parent);
    }

}