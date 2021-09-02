using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHand : MonoBehaviour
{

    public Scrollbar slider;
    public Animator anim;
    private float number;
    public int CountNumber;
    private int startNumber = 0;
    private bool isZero;
    private bool isOne;
    public GameObject particle;
    public GameObject[] particlePoints;
    public GameObject covids;
    public Animator textAnim;
    private float startValue;
    // Start is called before the first frame update
    void Start()
    {
        startValue = slider.value;
        isOne = false;
        isZero = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startValue != slider.value)
        {
            if (textAnim != null)
            {
                textAnim.SetBool("isFirst", false);
            }
        }

        number = slider.value;
        anim.SetFloat("speed",number);
        if(number == 0 && isZero) {
            startNumber++;
            isZero = false;
            isOne = true;
            for (int i = 0; i < particlePoints.Length; i++)
            {
                Instantiate(particle, particlePoints[i].transform.position, Quaternion.identity);
            }
        }
        if(number == 1 && isOne)
        {
            startNumber++;
            isOne = false;
            isZero = true;
            for (int i = 0; i < particlePoints.Length; i++)
            {
                Instantiate(particle, particlePoints[i].transform.position, Quaternion.identity);
            }
        }
        if(startNumber == CountNumber)
        {
            Destroy(covids.gameObject);
        }

    }
}
