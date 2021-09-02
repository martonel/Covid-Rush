using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashSystem : MonoBehaviour
{
    private GameObject[] littleCovids;
    private int phaseNumber;
    public Animator anim;
    public Animator textAnim;
    private bool isStart;
    public Animator endAnim;
    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        phaseNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        littleCovids =  GameObject.FindGameObjectsWithTag("LittleCovid");

        if(littleCovids.Length == 0 && isStart ==true)
        {
            Debug.Log(phaseNumber);
            
            if (phaseNumber == 0)
            {
                Debug.Log("second Phase");
                anim.Play("FirstHandsDown");
                phaseNumber++;
                isStart = false;
            }
            else if (phaseNumber == 1)
            {
                textAnim.Play("secondTextUp");
                anim.Play("SecondHandsDown");
                isStart = false;
                phaseNumber++;
            }
            else if (phaseNumber == 2)
            {
                Debug.Log("third Phase");
                anim.Play("CrossHandsDown");
                isStart = false;
                phaseNumber++;
            }
            else if (phaseNumber == 3)
            {
                Debug.Log("you win!");
                anim.Play("CrossHandsDown2");
                StartCoroutine(WaitTime());
                isStart = false;
                phaseNumber++;
            }
        }

        if(littleCovids.Length != 0)
        {
            isStart = true;
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2.0f);
        endAnim.Play("LevelEndUp");
    }
}
