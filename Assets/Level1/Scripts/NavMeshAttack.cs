using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAttack : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    public bool isMove;
    private Vector3 startPos;
    private Vector3 endPos;

    private int xNumber;
    private int zNumber;
    private int xPos;
    private int zPos;
    private bool isChange = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        xPos = Random.Range(1, 16);
        zPos = Random.Range(1, 16);
        xNumber = ((-8 + xPos) * 16) + 8;
        zNumber = ((-8 + zPos) * 16) + 8;
        endPos = new Vector3(xNumber, 0, zNumber);


        isMove = false;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == true)
        {
            //GetComponent<NavMeshAgent>().destination = player.transform.position;
            if (!GetComponent<NavMeshAgent>().pathPending)
            {
                if (GetComponent<NavMeshAgent>().remainingDistance <= GetComponent<NavMeshAgent>().stoppingDistance)
                {
                    if (!GetComponent<NavMeshAgent>().hasPath || GetComponent<NavMeshAgent>().velocity.sqrMagnitude == 0f)
                    {
                       if(anim != null)
                        {
                            anim.Play("Run");
                        }
                        if (isChange)
                        {
                            GetComponent<NavMeshAgent>().destination = startPos;
                            //Debug.Log("célba ért");
                            isChange = false;
                        }
                        else
                        {
                            GetComponent<NavMeshAgent>().destination = endPos;
                            //Debug.Log("vissza indult");
                            isChange = true;
                        }
                    }
                }
            }
           
        }
    }

    public void Stop()
    {
        isMove = false;
    }
    public void SetStart()
    {
        isMove = true;
    }
}


