using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFaces : MonoBehaviour
{

    public Color[] faceColors;
    public Color[] hairColors;
    public Color[] ShirtColor;
    public Color[] ShirtNeckColor;
    public Color[] MaskColor;
    public GameObject shirtDown;
    public GameObject shirtTop;
    public GameObject shirtNeck;
    public GameObject face;
    public GameObject hair;
    public GameObject hair2;
    public GameObject mask;
    private int rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 2);
        //Debug.Log("random number: " + rand);
        /*
        if(rand == 1)
        {
            hair2.SetActive(true);
            Destroy(hair.gameObject);
        }
        else
        {
            hair.SetActive(true);
            Destroy(hair2.gameObject);
        }*/

        //face colorized
        rand = Random.Range(0, faceColors.Length);
        shirtNeck.GetComponent<Image>().color = faceColors[rand];
        face.GetComponent<Image>().color = faceColors[rand];

        //shirt colorized
        rand = Random.Range(0, ShirtColor.Length);
        shirtDown.GetComponent<Image>().color = ShirtColor[rand];

        //shirtNeck colorized
        rand = Random.Range(0, ShirtNeckColor.Length);
        shirtTop.GetComponent<Image>().color = ShirtNeckColor[rand];

        //hair colorized
        rand = Random.Range(0, hairColors.Length);
        hair.GetComponent<Image>().color = hairColors[rand];

        //mask colorized
        if (mask != null)
        {
            rand = Random.Range(0, MaskColor.Length);
            mask.GetComponent<Image>().color = MaskColor[rand];
        }
    }
    public Color GetColor()
    {
        return shirtDown.GetComponent<Image>().color;
    }
}
