using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 pos;
    private Vector3 originalPos;
    private Vector3 finalPos;
    private Vector3 newPos;
    private bool isMove = false;
    public float moveSpeed;
    public Vector3 originalRotation;
    public bool isFollow = false;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = new Vector3(this.gameObject.transform.rotation.x, this.gameObject.transform.rotation.y, this.gameObject.transform.rotation.z);
        originalPos = pos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isFollow)
        {
            if (isMove)
            {
                pos = Vector3.MoveTowards(pos, newPos, moveSpeed * Time.deltaTime);

                if (pos == newPos)
                {
                    isMove = false;
                }
            }

            this.gameObject.transform.parent = player.transform;
            this.gameObject.transform.position = player.transform.position + new Vector3(0, 4, 0);
            //finalPos = new Vector3(player.transform.position.x + pos.x, 0 + pos.y, player.transform.position.z + pos.z);
            //this.gameObject.transform.position = finalPos;
        }
        else
        {
            finalPos = new Vector3(player.transform.position.x + pos.x, player.transform.position.y + pos.y, player.transform.position.z + pos.z);
            this.gameObject.transform.position = finalPos;
        }
    }
    public void VectorUpdate(Vector3 plusPos)
    {
        newPos = originalPos + plusPos;
        isMove = true;
    }
}
