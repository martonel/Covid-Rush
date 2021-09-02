using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnbedBehaviour : MonoBehaviour
{
    Rigidbody rb;
    private GameObject parentObj;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        parentObj = other.gameObject;
        Embed();
        if (other.transform.tag == "Enemy") {
            GameObject enemyObj = other.gameObject;
            enemyObj.transform.Find("Hat").GetComponent<SkinnedMeshRenderer>().materials[0].color = Color.green;
            enemyObj.transform.Find("Hat").GetComponent<SkinnedMeshRenderer>().materials[1].color = Color.green;
            enemyObj.transform.Find("Clothes").GetComponent<SkinnedMeshRenderer>().materials[0].color = Color.green;


            player.GetComponent<VakcineShoot>().SetHitNumber();
            Destroy(this.gameObject);

        }
    }
    void Embed() {
        //this.gameObject.transform.parent = parentObj.transform;
        transform.GetComponent<ProjectileAddForce>().enabled = false;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        rb.isKinematic = true;
        if (this.gameObject.GetComponent<BoxCollider>() != null)
        {
            Component[] collider;

            collider = GetComponents(typeof(BoxCollider));

            foreach (BoxCollider col in collider)
            {
                col.enabled = false;
            }
        }
    }
}
