using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class UITextTypeWriter: MonoBehaviour
{

	Text txt;
	string story;
	public float startWaitTime;
	public float speed=1.0f;
	void Awake()
	{
		txt = GetComponent<Text>();
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine("PlayText");
	}

	private int number;
	IEnumerator PlayText()
	{
		number = 0;
		yield return new WaitForSeconds(startWaitTime);
		foreach (char c in story)
		{
			FindObjectOfType<AudioManager>().Play("textMusic");
			number++;
			txt.text += c;
			yield return new WaitForSeconds(0.1f/speed);
		}
	}

}