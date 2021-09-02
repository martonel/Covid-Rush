using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canPlayerMove = false;
    private Rigidbody rb;


    public float speed = 10.0f;
    public float rotationSpeed = 0.5f;
    [Header("Jump settings")]
    public float jumpForce = 3.0f;
    public float gravityForce = 5.0f;

    private bool isgrounded = false;
    public Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (canPlayerMove)
        {
            float yRotation;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.Play("Run");
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else
            {
                anim.Play("Ideal");
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                yRotation = Mathf.Lerp(transform.eulerAngles.y, transform.eulerAngles.y - 360, rotationSpeed * Time.deltaTime);
                if (transform.eulerAngles.y > 360)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 360, transform.eulerAngles.z);
                }
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                yRotation = Mathf.Lerp(transform.eulerAngles.y, transform.eulerAngles.y + 360, rotationSpeed * Time.deltaTime);
                if (transform.eulerAngles.y > 360)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 360, transform.eulerAngles.z);
                }
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            }
        }
        else
        {
            anim.Play("Ideal");
        }

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isgrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        if (!isgrounded)
        {

            rb.AddForce(Vector2.down * gravityForce);
        }

       


    }
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isgrounded = true;
        }
    }
    void OnCollisionStay(Collision theCollision)
    {
        if (theCollision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isgrounded = true;
        }
    }
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isgrounded = false;
        }
    }
    public void IsMove(bool isMove)
    {
        canPlayerMove = isMove;
    }
}