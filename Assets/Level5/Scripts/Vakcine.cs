using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vakcine : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.x-100.0f, rb.velocity.y-100.0f) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
