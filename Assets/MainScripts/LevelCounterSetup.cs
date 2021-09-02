using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCounterSetup : MonoBehaviour
{
    private GameObject[] GameManager;
    [SerializeField]
    private bool LastScene;

    private void Start()
    {
        if(LastScene == true)
        {
            SetCounter(0);
        }
    }
    public void CounterPlus()
    {
        GameManager = GameObject.FindGameObjectsWithTag("gameManager");
        if (GameManager != null)
        {
            GameManager[0].GetComponent<GameManager>().SetBookSheetNumberCounter(true);
        }
    }
    public void SetCounter(int number)
    {
        GameManager = GameObject.FindGameObjectsWithTag("gameManager");
        if (GameManager != null)
        {
            GameManager[0].GetComponent<GameManager>().SetCounter(number);
        }
    }
}
