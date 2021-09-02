using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSponge : MonoBehaviour
{

    private Vector3 worldPos;
    public bool isMove;
    public GameObject soapParticle;
    private Vector3 startPos;
    public Animator anim;

    private void Start()
    {
        isMove = false;
        startPos = this.transform.position;
    }
    private void OnMouseDrag()
    {
        anim.SetBool("isFirst", true);
    }
    private void OnMouseDown()
    {
        isMove = true;

    }
    private void OnMouseUp()
    {
        isMove = false;
        this.transform.position = startPos;
    }
    private void Update()
    {
        if (isMove)
        {
            Instantiate(soapParticle, this.transform.position, Quaternion.identity);
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            this.transform.position = worldPos;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "LittleCovid")
        {
            CovidHealth health = other.gameObject.GetComponent<CovidHealth>();
            if (health != null)
            {
                health.HealthMinus();
            }
        }
    }
}
