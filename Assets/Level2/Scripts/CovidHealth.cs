using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidHealth : MonoBehaviour
{

    public float health;
    public float downSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HealthMinus()
    {
        health -= downSpeed * Time.deltaTime;
        if(health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
