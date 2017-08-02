using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBubble : MonoBehaviour {
	private GameObject textbubble;
	// Use this for initialization
	void Start () {
		textbubble = GameObject.Find("TextBubble");
	}

	// Update is called once per frame
	void Update () {
		int destroyTime = 5; 
		Destroy(textbubble, destroyTime); 
	}
}
