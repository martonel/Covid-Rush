using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSetup : MonoBehaviour
{

    [SerializeField]
    private GameObject mask;

    private GameObject people;
    private List<GameObject> peoples = new List<GameObject>();
    void Start()
    {
        int count = gameObject.transform.childCount;
        int rand = Random.Range(0, count);
        for (int i = 0; i < count; i++)
        {
            if (rand != i)
            {
                people = gameObject.transform.GetChild(i).GetChild(3).GetChild(3).gameObject;
                gameObject.transform.GetChild(i).GetChild(3).GetChild(3).GetComponent<CircleCollider2D>().enabled = false;
                Instantiate(mask, people.gameObject.transform.position, Quaternion.identity, people.transform);
            }
        }

    }
}
