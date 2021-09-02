using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsUp : MonoBehaviour
{
    public GameObject lighting;
    private void Start()
    {
        lighting.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            lighting.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lighting.gameObject.SetActive(false);
        }
    }
}
