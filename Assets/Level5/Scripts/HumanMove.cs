using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private bool isLeft;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        anim.Play("Run");
        anim.speed = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    public void SetDir(bool leftOrRight)
    {
        isLeft = leftOrRight;
    }


}
