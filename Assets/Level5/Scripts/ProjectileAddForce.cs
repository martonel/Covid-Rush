using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddForce : MonoBehaviour
{

    //https://www.youtube.com/watch?v=YOP49qGzR8Y&list=RDCMUCJeim1BU1ZXAk224yXqlRVg&index=1
    Rigidbody rb;
    public float shootForce = 2000;


    public void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        ApplyForce();
    }
    // Start is called before the first frame update
    void Start()
    {
        SpinObjectInAir();

    }

    // Update is called once per frame
    void Update()
    {
        SpinObjectInAir();
    }
    private void ApplyForce()
    {
        rb.AddRelativeForce(Vector3.forward*shootForce);
    }

    private void SpinObjectInAir()
    {
        float yVelocity = rb.velocity.y;
        float zVelocity = rb.velocity.z;
        float xVelocity = rb.velocity.x;
        float combinedVelocity = Mathf.Sqrt(xVelocity * xVelocity + zVelocity * zVelocity);
        float fallAngle = -1 * Mathf.Atan2(yVelocity, combinedVelocity) * 180 / Mathf.PI;
        transform.eulerAngles = new Vector3(fallAngle, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
