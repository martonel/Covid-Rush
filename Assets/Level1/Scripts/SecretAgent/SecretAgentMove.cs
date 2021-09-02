using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class SecretAgentMove : MonoBehaviour
{
    public float range;
    public GameObject player;

    private bool isMove;
    private Vector3 startPos;
    private Vector3 endPos;

    private int xNumber;
    private int zNumber;
    private int xPos;
    private int zPos;

    private bool isChange = false;
    public Animator anim;
    private bool playerDistane = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        startPos = this.transform.position;
        Counter();
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isMove == true)
        {


            if (Vector3.Distance(player.transform.position, transform.position) <= range)
            {
                if(playerDistane == true)
                {
                    player.gameObject.GetComponent<PlayerFollower>().SetNumber(true);
                    playerDistane = false;
                }
                if(Mathf.Abs(this.transform.position.x - player.transform.position.x) <= 1.0f ||
                    Mathf.Abs(this.transform.position.z - player.transform.position.z) <= 1.0f)
                {
                    GetComponent<NavMeshAgent>().isStopped = true;
                    anim.Play("Ideal");
                }
                else
                {
                    Debug.Log("Közeledik: " + Mathf.Abs(this.transform.position.x - player.transform.position.x));
                    GetComponent<NavMeshAgent>().isStopped = false;
                    anim.Play("Run");
                    GetComponent<NavMeshAgent>().destination = player.transform.position;
                }

            }
            else if (!GetComponent<NavMeshAgent>().pathPending)
            {
                if (playerDistane == false)
                {
                    player.gameObject.GetComponent<PlayerFollower>().SetNumber(false);
                    playerDistane = true;
                }


                if (GetComponent<NavMeshAgent>().remainingDistance <= GetComponent<NavMeshAgent>().stoppingDistance)
                {
                    if (!GetComponent<NavMeshAgent>().hasPath || GetComponent<NavMeshAgent>().velocity.sqrMagnitude == 0f)
                    {
                        if (anim != null)
                        {
                            anim.Play("Ideal");
                        }
                        if (isChange)
                        {
                            startPos = endPos;
                            while(endPos == startPos)
                            {
                                Counter();
                            }
                            GetComponent<NavMeshAgent>().destination = endPos;
                            Debug.Log(endPos);
                            isChange = false;
                        }
                        else
                        {
                            startPos = endPos;
                            while (endPos == startPos)
                            {
                                Counter();
                            }
                            GetComponent<NavMeshAgent>().destination = endPos;
                            Debug.Log(endPos);
                            isChange = true;
                        }
                    }
                }
                else
                {
                    if (anim != null)
                    {
                        anim.Play("Run");
                    }
                }
            }
        }
    }
    private void Counter()
    {
        xPos = Random.Range(1, 16);
        zPos = Random.Range(1, 16);
        xNumber = ((-8 + xPos) * 16) + 8;
        zNumber = ((-8 + zPos) * 16) + 8;
        endPos = new Vector3(xNumber, 0, zNumber);
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
