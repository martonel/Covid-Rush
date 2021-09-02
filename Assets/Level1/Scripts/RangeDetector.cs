using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeDetector : MonoBehaviour
{
    public float size = 1.5f;
    private float upSize = 0.0f;
    public float upSpeed = 5.0f;
    public Material changeMat;
    private Vector3 sizeVec;


    private GameObject parentObj;
    private float t;
    public float duration = 1.5f;
    private Color startColor;
    private Animator anim;
    public int Damage = 1;
    private GameObject PlayerObj;
    private bool WaitBool = true;
    //public MeshRenderer[] materials;
    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.FindGameObjectsWithTag("Player")[0];
        parentObj = this.gameObject.transform.parent.gameObject;
        startColor = parentObj.GetComponent<MeshRenderer>().material.color;
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        if (this.gameObject.transform.parent.tag != "Player")
        {
            materials = GetChilds();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.parent.tag != "Player")
        {
            if (t < 1)
            {
                if (materials.Length != 0)
                {
                    for (int i = 0; i < materials.Length; i++)
                    {
                        materials[i].color = Color.Lerp(startColor, Color.red, t);
                    }
                }
                //parentObj.GetComponent<MeshRenderer>().material.color = Color.Lerp(startColor, Color.red, t);
                t += Time.deltaTime / duration;
            }
        }
        if (this.gameObject.transform.localScale.x <= size)
        {
            upSize += upSpeed * Time.deltaTime;
            sizeVec = new Vector3(upSize, upSize, 1.0f);
            this.gameObject.transform.localScale = sizeVec;
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.transform.childCount == 2)
            {
                Vector3 plusVec = new Vector3(0, -0.4f, 0);

                var myNewSmoke = Instantiate(this.gameObject, other.transform.position + plusVec, Quaternion.identity);
                myNewSmoke.transform.Rotate(90, 0, 0, Space.World);
                myNewSmoke.transform.parent = other.transform;
            }
        }
        if (other.gameObject.tag == "Player")
        {
            if (other.transform.childCount == 4 && WaitBool == true)
            {
                Debug.Log("Player hozzáér!");
                PlayerDamage();
                WaitBool = false;
                StartCoroutine(WaitTime());
            }
        }

    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3.0f);
        WaitBool = true;
    }

    public void PlayerDamage()
    {
        PlayerObj.GetComponent<PlayerHealth>().GetDamage(Damage);
        if (PlayerObj.GetComponent<PlayerHealth>().GetHealth() <= 0)
        {
            EndOfGame();
        }
    }
    void EndOfGame()
    {
        GameObject[] Enenies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enenies.Length; i++)
        {
            Enenies[i].GetComponent<NavMeshAttack>().Stop();
            Enenies[i].GetComponent<NavMeshAgent>().enabled = false;
        }
        PlayerObj.gameObject.GetComponent<PlayerMovement>().IsMove(false);
        PlayerObj.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        anim = GameObject.FindGameObjectsWithTag("Restart")[0].GetComponent<Animator>();
        anim.SetBool("isTrue", true);

        Vector3 plusVec = new Vector3(0, -0.4f, 0);

        var myNewSmoke = Instantiate(this.gameObject, PlayerObj.transform.position + plusVec, Quaternion.identity);
        myNewSmoke.transform.Rotate(90, 0, 0, Space.World);
        myNewSmoke.transform.parent = PlayerObj.transform;
    }


    private Material[] GetChilds()
    {
        
        Material[] CoviddMaterials = new Material[1];
        GameObject covidObj  = GetChildWithName(parentObj, "3DCovid");
        MeshRenderer CovidRenderer;
        CovidRenderer =  covidObj.GetComponent<MeshRenderer>();
        CoviddMaterials[0] = CovidRenderer.material;
        /*
                birdRenderer = GetChildWithName(birdObj, "Leg_Right").GetComponent<MeshRenderer>();
                birdMaterials[2] = birdRenderer.material;

                birdRenderer = GetChildWithName(birdObj, "Leg_Right (1)").GetComponent<MeshRenderer>();
                birdMaterials[3] = birdRenderer.material;

                birdRenderer = GetChildWithName(birdObj, "Head").GetComponent<MeshRenderer>();
                birdMaterials[4] = birdRenderer.material;
        */
        return CoviddMaterials;
    }
    private GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }
}