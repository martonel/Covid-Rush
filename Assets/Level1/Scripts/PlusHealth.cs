using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusHealth : MonoBehaviour
{
    public int plus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().PlusHealth(plus);
            Destroy(this.gameObject);
        }
    }
}
