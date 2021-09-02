using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootVakcine : MonoBehaviour
{

    public GameObject vakcine;
    public float launchForce;
    public Transform shotPoint;
    public GameObject point;
    private GameObject[] points;
    public int numberOfPoints;
    public float speedBetweenPoints;
    private Vector2 dir;

    private void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }
    void Update()
    {
        Vector2 vakcinePos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePos - vakcinePos;
        transform.right = dir;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPos(i * speedBetweenPoints);
        }
    }

    public void Shoot()
    {
        GameObject newVakcine = Instantiate(vakcine, shotPoint.position, shotPoint.rotation);
        newVakcine.GetComponent<Rigidbody>().velocity = transform.right * launchForce;
    }

    private Vector2 PointPos(float t)
    {
        Vector2 pos = (Vector2)shotPoint.position + (dir.normalized * launchForce* t)+0.5f*Physics2D.gravity*(t*t);
        return pos;
    }
}

