using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSystem : MonoBehaviour
{

    private bool isTrue;
    public Animator anim;
    public bool isButtonDown;
    public GameObject miniGame;
    // Start is called before the first frame update
    void Start()
    {
        isButtonDown = false;
        isTrue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrue)
        {
            if (Input.GetKeyDown(KeyCode.X) && isButtonDown == false)
            {

                StartNewGame();
                isButtonDown = true;
                Invoke("End", 0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTrue = true;
            this.gameObject.transform.GetComponent<Animator>().Play("ButtonUp");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTrue = false;
            this.gameObject.transform.GetComponent<Animator>().Play("ButtonDown");
        }
    }
    private void End()
    {
        Destroy(this.gameObject);
    }

    private void StartNewGame()
    {
        Instantiate(miniGame, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
