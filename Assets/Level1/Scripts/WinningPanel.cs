using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WinningPanel : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerFollower>().GetNumber() >= 3)
            {
                GameObject[] Enenies = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < Enenies.Length; i++)
                {
                    Enenies[i].GetComponent<NavMeshAttack>().Stop();
                    Enenies[i].GetComponent<NavMeshAgent>().enabled = false;
                }
                other.gameObject.GetComponent<PlayerMovement>().IsMove(false);
                other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                anim.Play("LevelEndUp");
            }
        }
    }
}
