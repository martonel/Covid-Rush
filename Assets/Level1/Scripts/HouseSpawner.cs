using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HouseSpawner : MonoBehaviour
{
    public int size = 4;
    private Vector3[,] spawnPoints;
    public GameObject house;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int halfPoint = size / 2;
        spawnPoints = new Vector3[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                spawnPoints[i,j] = new Vector3((i-halfPoint)*16,0,(j-halfPoint)*16);
            }
        }
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject houseObj = Instantiate(house.gameObject, spawnPoints[i, j], Quaternion.identity);
                GameObject parentObj = GameObject.FindGameObjectsWithTag("HouseComplex")[0];
                houseObj.transform.parent = parentObj.transform;
                int rnd = Random.Range(1, 5);
                if(rnd == 1) { houseObj.transform.rotation = Quaternion.Euler(0, 90.0f, 0); }
                if(rnd == 2) { houseObj.transform.rotation = Quaternion.Euler(0, 180.0f, 0); }
                if(rnd == 3) { houseObj.transform.rotation = Quaternion.Euler(0, 270.0f, 0); }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
