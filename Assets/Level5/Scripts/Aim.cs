using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    //https://www.youtube.com/watch?v=g6AI5LWYLls&list=RDCMUCJeim1BU1ZXAk224yXqlRVg&index=4
    Rigidbody rb;
    [SerializeField]
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Cursor.visible = false;
        cam = GetComponentInChildren<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            AimLogic();
        }
    }
    void AimLogic()
    {
        float leftRightValue = Input.GetAxisRaw("Mouse X");
        float upDownValue = Input.GetAxisRaw("Mouse Y");
        Vector3 rotationX = new Vector3(upDownValue*2, 0, 0);
        Vector3 rotationY = new Vector3(0,leftRightValue*2, 0);

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotationY));
        cam.transform.Rotate(-1*rotationX / 3);
    }


}
