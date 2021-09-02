using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public int followersNumber;
    // Start is called before the first frame update
    void Start()
    {
        followersNumber = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNumber(bool isTrue)
    {
        if (isTrue)
        {
            followersNumber++;
        }
        else
        {
            followersNumber--;
        }
        Debug.Log(followersNumber);
    }
    public int GetNumber()
    {
        return followersNumber;
    }
}
