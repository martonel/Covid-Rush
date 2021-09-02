using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskCounter : MonoBehaviour
{
    public int maskNumber;
    public int levelCounter;
    private Animator anim;
    public Animator endAnim;
    [SerializeField]
    private GameObject[] waves;
    public Text levelText;


    private void Start()
    {
        Instantiate(waves[0], this.gameObject.transform.position,Quaternion.identity,this.gameObject.transform);
        waves[0].transform.SetAsLastSibling();
        levelText.text = levelCounter + ". szint";
    }
    private void Update()
    {
        if(maskNumber == 1)
        {
            if(levelCounter < waves.Length-1)
            {
                SetUp(); 
               
            }
            else
            {
                LastSetUp();
            }
        }
    }

    public void SetUp()
    {
        maskNumber = 0;
        levelCounter++; 
        levelText.text = levelCounter + ". szint";
        anim = GameObject.FindGameObjectsWithTag("Respawn")[0].GetComponent<Animator>();
        anim.Play("3FaceDown");
        StartCoroutine(WaitTime());
    }

    private void LastSetUp()
    {
        maskNumber = 0;
        levelCounter++;
        levelText.text = levelCounter + ". szint";
        anim = GameObject.FindGameObjectsWithTag("Respawn")[0].GetComponent<Animator>();
        anim.Play("3FaceDown"); 
        StartCoroutine(LastWaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(GameObject.FindGameObjectsWithTag("Respawn")[0]);
        Instantiate(waves[levelCounter], this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
        waves[levelCounter].transform.SetAsLastSibling();
    }
    IEnumerator LastWaitTime()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(GameObject.FindGameObjectsWithTag("Respawn")[0]);
        endAnim.Play("LevelEndUp");
    }

    public void SetMaskNumber()
    {
        maskNumber++;
    }
}
