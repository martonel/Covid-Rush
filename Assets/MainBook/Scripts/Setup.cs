using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    public string screenName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectSceen()
    {
        Debug.Log("almafa!");
    }
    public void GameEnd()
    {
        Application.Quit();
    }
}
