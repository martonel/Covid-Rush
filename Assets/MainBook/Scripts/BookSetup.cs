using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookSetup : MonoBehaviour
{

    public Button rightArrow;
    public Button leftArrow;
    public Animator anim;
    private string rightButtonName;
    private string leftButtonName;
    private int counter;
    private GameObject[] GameManager;

    private void Start()
    {
        GameManager = GameObject.FindGameObjectsWithTag("gameManager");
        counter = 0;
        if (GameManager != null)
        {
            if (GameManager[0].GetComponent<GameManager>().GetBookSheetNumberCounter() >= 1)
            {
                Debug.Log("változás: " + GameManager[0].GetComponent<GameManager>().GetBookSheetNumberCounter());
                counter = GameManager[0].GetComponent<GameManager>().GetBookSheetNumberCounter()-1;
                Calculation();
                Counter(false);
                GameManager[0].GetComponent<GameManager>().SetBookSheetNumberCounter(false);
            }
        }
        if(counter ==0)
        {
            anim.Play("StartAnimation");
            rightButtonName = "Level1ToLevel2";
            leftButtonName = "";
        }
    }
    public void Counter(bool isNegative)
    {
        if (isNegative)
        {
            anim.Play(leftButtonName);
            counter--;
            GameManager[0].GetComponent<GameManager>().SetBookSheetNumberCounter(false);
        }
        else
        {
            anim.Play(rightButtonName);
            counter++;
            GameManager[0].GetComponent<GameManager>().SetBookSheetNumberCounter(true);

        }
        Invoke("Calculation", 1.0f);
    }
    public void Calculation()
    {
        if(counter == 0)
        {
            rightButtonName = "Level1ToLevel2";
            leftButtonName = "";
        }
        else if(counter == 1)
        {
            rightButtonName = "Level2ToLevel3";
            leftButtonName = "Level2ToLevel1";
        }
        else if(counter == 2)
        {
            rightButtonName = "Level3ToLevel4";
            leftButtonName = "Level3ToLevel2";
        }
        else if(counter == 3)
        {

            rightButtonName = "Level4ToLevel5";
            leftButtonName = "Level4ToLevel3";
        }
        else if(counter == 4)
        {
            rightButtonName = "LastLevelToEnd";
            leftButtonName = "Level5ToLevel4";
        }
        else if (counter == 5)
        {
            leftButtonName = "EndToLastLevel";
        }
        Debug.Log(counter);
    }

}
