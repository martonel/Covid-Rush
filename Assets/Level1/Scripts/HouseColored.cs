using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseColored : MonoBehaviour
{
    public GameObject house1;
    public GameObject house2;
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, materials.Length);
        Debug.Log(rand);
        house1.GetComponent<MeshRenderer>().materials[1].color = materials[rand].color;
        house2.GetComponent<MeshRenderer>().materials[1].color = materials[rand].color;
    }
}
