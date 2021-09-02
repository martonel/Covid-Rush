using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetAudio : MonoBehaviour
{


    private bool isMute = false;
    public Sprite simpleAudioImage;
    public Sprite muteAudioImage;

    private void Awake()
    {
        isMute = FindObjectOfType<GameManager>().GetMute();
        if(isMute != true)
        {
            isMute = false;
            Mute();
            Debug.Log("hangtalan");
        }
        else
        {
            isMute = true;
            Mute();
            Debug.Log("hangos");
        }
    }
    public void SetPlay(string name)
    {

        FindObjectOfType<AudioManager>().Play(name);

    }
    public void Mute()
    {
        GameObject[] audioObj = GameObject.FindGameObjectsWithTag("AudioButton");
        isMute = !isMute;
        if (isMute)
        {
            if (audioObj != null)
            {
                audioObj[0].GetComponent<Image>().sprite = simpleAudioImage;
            }
            AudioSource[] audio = FindObjectOfType<AudioManager>().GetComponents<AudioSource>();
            foreach (AudioSource a in audio)
            {
                a.enabled = true;
            }
            FindObjectOfType<GameManager>().SetMute(false);
        }
        else
        {
            if (audioObj != null)
            {
                audioObj[0].GetComponent<Image>().sprite = muteAudioImage;
            }
            AudioSource[] audio = FindObjectOfType<AudioManager>().GetComponents<AudioSource>();
            foreach (AudioSource a in audio)
            {
                a.enabled = false;
            }
            FindObjectOfType<GameManager>().SetMute(true);
        }
    }
}
