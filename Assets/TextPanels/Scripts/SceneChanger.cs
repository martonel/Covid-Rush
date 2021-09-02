using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    public bool isDown;
    public float waitingTime;
    public SceneFader SceneFader;

    void Update()
    {
        if (isDown == true)
        {
            StartCoroutine(WaitTime());
            isDown = false;
        }
    }
    IEnumerator WaitTime()
    {
        Debug.Log("elindult");
        yield return new WaitForSeconds(waitingTime);
        SceneFader.FadeTo(sceneName);
    }
}
