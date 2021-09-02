using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StartFirstScene : MonoBehaviour
{
    private GameObject[] player;
    private GameObject[] enemy;
    public GameObject[] secretEnemy;
    public float waitTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.1f);
        player = GameObject.FindGameObjectsWithTag("Player");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        secretEnemy = GameObject.FindGameObjectsWithTag("SecretAgent");
        
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<NavMeshAttack>().SetStart();
            enemy[i].GetComponent<NavMeshAgent>().enabled = true;
        }
        for (int i = 0; i < secretEnemy.Length; i++)
        {
            secretEnemy[i].GetComponent<NavMeshAgent>().enabled = true;
            secretEnemy[i].GetComponent<SecretAgentMove>().SetStart();
        }

        yield return new WaitForSeconds(waitTime);

        for (int i = 0; i < player.Length; i++)
        {
            player[i].GetComponent<PlayerMovement>().IsMove(true);
        }
    }
}
