using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject leftSpawnPoint;

    [SerializeField]
    private GameObject rightSpawnPoint;
    [SerializeField]
    private GameObject Runner;

    private int rand;
    private bool isTrue;
    
    // Start is called before the first frame update
    void Start()
    {
        isTrue = false;
        StartCoroutine(WaitTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrue)
        {
            StartCoroutine(WaitTime());
            isTrue = false;
        }
    }


    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3.0f);
        rand = Random.Range(0, 2);
        if(rand == 0)
        {
            GameObject obj = Instantiate(Runner, leftSpawnPoint.transform.position, Quaternion.identity);
            obj.GetComponent<HumanMove>().SetDir(true);
        }
        if(rand == 1)
        {
            GameObject obj = Instantiate(Runner, rightSpawnPoint.transform.position, Quaternion.identity);
            obj.GetComponent<HumanMove>().SetDir(false);
        }
        isTrue = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
