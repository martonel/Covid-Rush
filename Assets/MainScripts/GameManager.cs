using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bookSheetNumber = 0;
    public bool Mute;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("gameManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }
    private void Start()
    {

        FindObjectOfType<AudioManager>().Play("mainTheme");
    }

    public int GetBookSheetNumberCounter()
    {
        return bookSheetNumber;
    }
    public void SetBookSheetNumberCounter(bool isTrue)
    {
        if (isTrue) {
            bookSheetNumber++;
        }
        else
        {
            bookSheetNumber--;
        }
    }
    public void SetMute(bool isTrue)
    {
        Mute = isTrue;
    }
    public bool GetMute()
    {
        return Mute;
    }

    public void SetCounter(int number)
    {
        bookSheetNumber = number;
    }
}
