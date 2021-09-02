using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed;
    public Animator anim;
    private bool HelloBool;
    private bool isMove;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        isMove = true;
        HelloBool = false;
    }

    void FixedUpdate()
    {
        if (isMove)
        {
            float Move = Input.GetAxisRaw("Horizontal");
            if (!HelloBool)
            {
                float x = Input.GetAxis("Horizontal");
                Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
                rb.velocity = move;


                if (Move == -1)
                {
                    anim.Play("Run");
                    //this.gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
                    this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (Move == 1)
                {
                    anim.Play("Run");
                    //this.gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
                    this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (Move == 0)
                {
                    anim.Play("Ideal");
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play("Hello");
                HelloBool = true;
                Invoke("hello", 1.8f);
                this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
    }
    public void hello()
    {
        HelloBool = false;
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void Ending()
    {
        HelloBool = true;
    }
    public void SetMove(bool isTrue)
    {
        isMove = isTrue;
    }

}
