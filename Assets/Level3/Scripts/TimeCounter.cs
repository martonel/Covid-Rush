using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{

    public float timeValue = 120;
    public Text timeText;
    public Animator anim;
    public Animator EndAnim;
    private PlayerMovement2D playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove =  GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else 
        {
            //timeValue += 90 //repeat event
            timeValue = 0;
            StartCoroutine(WaitTime());
            playerMove.Ending();
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisPlay)
    {
        if(timeToDisPlay < 0)
        {
            timeToDisPlay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisPlay / 60);
        float seconds = Mathf.FloorToInt(timeToDisPlay % 60);
        timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    public void SetTimmer(float number)
    {
        if (timeValue - number >= 0.0f)
        {
            timeValue -= number;
        }
        else
        {
            timeValue = 0.0f;
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2.0f);
        anim.Play("Win");
        yield return new WaitForSeconds(1.0f);
        EndAnim.Play("LevelEndUp");
    }
}



//https://www.youtube.com/watch?v=HmHPJL-OcQE&t=2s