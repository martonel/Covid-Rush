using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    private int xNumber;
    private int zNumber;
    private int xPos;
    private int zPos;
    public GameObject Enemy;
    public GameObject Simple_Enemy;
    public int enemiesNumber;
    public GameObject PlusHealthObj;
    public int PlusHealthNumber;
    public GameObject SecretAgent;
    public int SecretAgentNumber;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SecretAgentNumber; i++)
        {
            xPos = Random.Range(1, 16);
            zPos = Random.Range(1, 16);
            xNumber = ((-8 + xPos) * 16) + 8;
            zNumber = ((-8 + zPos) * 16) + 8;
            Vector3 pos = new Vector3(xNumber, 0, zNumber);
            GameObject enemyObj = Instantiate(SecretAgent, pos, Quaternion.identity);
            GameObject parentObj = GameObject.FindGameObjectsWithTag("Enemies")[0];
            enemyObj.transform.parent = parentObj.transform;
        }

        int halfnum = enemiesNumber / 2;
        for (int i = 0; i < halfnum; i++)
        {
            xPos = Random.Range(1, 16);
            zPos = Random.Range(1, 16);
            xNumber = ((-8 + xPos) * 16) + 8;
            zNumber = ((-8 + zPos) * 16) + 8;
            Vector3 pos = new Vector3(xNumber, 0, zNumber);
            GameObject enemyObj = Instantiate(Enemy, pos, Quaternion.identity);
            GameObject parentObj = GameObject.FindGameObjectsWithTag("Enemies")[0];
            enemyObj.transform.parent = parentObj.transform;
        }
        for (int i = 0; i < halfnum; i++)
        {
            xPos = Random.Range(1, 16);
            zPos = Random.Range(1, 16);
            xNumber = ((-8 + xPos) * 16) + 8;
            zNumber = ((-8 + zPos) * 16) + 8;
            Vector3 pos = new Vector3(xNumber, 0, zNumber);
            GameObject enemyObj = Instantiate(Simple_Enemy, pos, Quaternion.identity);
            GameObject parentObj = GameObject.FindGameObjectsWithTag("Enemies")[0];
            enemyObj.transform.parent = parentObj.transform;
        }
        for (int i = 0; i < PlusHealthNumber; i++)
        {
            xPos = Random.Range(1, 16);
            zPos = Random.Range(1, 16);
            xNumber = ((-8 + xPos) * 16) + 8;
            zNumber = ((-8 + zPos) * 16) + 8;
            Vector3 pos = new Vector3(xNumber, 0, zNumber);
            GameObject enemyObj = Instantiate(PlusHealthObj, pos, Quaternion.identity);
            GameObject parentObj = GameObject.FindGameObjectsWithTag("Enemies")[0];
            enemyObj.transform.parent = parentObj.transform;
        }
    }
}
