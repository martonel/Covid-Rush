using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    private GameObject bulletPrefab;
    public GameObject spawnpoint;
    public float bulletSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            bulletPrefab =  Instantiate(bullet, spawnpoint.transform.position, this.gameObject.transform.rotation);
            bulletPrefab.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
        }
    }
}
