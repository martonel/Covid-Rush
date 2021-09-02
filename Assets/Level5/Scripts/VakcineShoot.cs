using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VakcineShoot : MonoBehaviour
{
    [SerializeField]
    private float pullSpeed;
    [SerializeField]
    private GameObject vakcinePrefab;
    [SerializeField]
    private GameObject vakcine;
    [SerializeField]
    private int numberOfVakcine = 10;
    [SerializeField]
    private GameObject bow;
    private bool vakcineSlotted = false;
    [SerializeField]
    private float pullAmount = 0;

    [SerializeField]
    private Animator endAnim;

    [SerializeField]
    private int maxHitNumber;



    [SerializeField]
    private Text vaccinationText;
    private int hitNumber;
    // Start is called before the first frame update
    void Start()
    {
        SpawnVakcine();
        vaccinationText.text = "Találat: " + hitNumber + "/" + maxHitNumber;
    }

    // Update is called once per frame
    void Update()
    {
        ShootLogic();

    }
    public void SpawnVakcine()
    {
        if(numberOfVakcine > 0)
        {
            vakcineSlotted = true;
            vakcine = Instantiate(vakcinePrefab, transform.position, transform.rotation) as GameObject;
            vakcine.transform.parent = transform;
        }
    }
    public void ShootLogic()
    {
        if (numberOfVakcine > 0)
        {
            if (pullAmount > 100)
            {
                pullAmount = 100;
            }
        }
        // SkinnedMeshRenderer _bowSkin = bow.transform.GetComponent<SkinnedMeshRenderer>();
        //  SkinnedMeshRenderer _vakcineSkin = vakcine.transform.GetComponent<SkinnedMeshRenderer>();


        if (Time.timeScale != 0)
        {
            if (vakcine != null)
            {
                Rigidbody _vakcineRb = vakcine.transform.GetComponent<Rigidbody>();
                ProjectileAddForce _vakcineProjectile = vakcine.transform.GetComponent<ProjectileAddForce>();

                if (Input.GetMouseButton(0))
                {
                    pullAmount += Time.deltaTime * pullSpeed;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    vakcineSlotted = false;
                    _vakcineRb.isKinematic = false;
                    vakcine.transform.parent = null;
                    _vakcineProjectile.shootForce = _vakcineProjectile.shootForce * ((pullAmount / 100) + 0.5f);
                    numberOfVakcine -= 1;
                    pullAmount = 0;
                    _vakcineProjectile.enabled = true;
                }
                //  _bowSkin.SetBlendShapeWeight(0, pullAmount);
                //   _vakcineSkin.SetBlendShapeWeight(0, pullAmount);
            }
            if (Input.GetMouseButton(0) && vakcineSlotted == false)
            {
                SpawnVakcine();
            }
        }

    }
    public void SetHitNumber()
    {
        hitNumber++;
        vaccinationText.text = "Találat: " + hitNumber+"/"+maxHitNumber;
        if (hitNumber >= maxHitNumber)
        {
            SetTime(0);
            Debug.Log("end");
            endAnim.Play("LevelEndUp");
        }
    }

    public void SetTime(int timeScale)
    {

        Time.timeScale = timeScale;
    }
}
