using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class canvasButtons : MonoBehaviour {
    //loads game scene
    public Canvas canvas;

	void Start () {
		canvas.enabled = false;
	}

	public void openCanvas(){
		canvas.enabled = true;
	}

	public void closeCanvas(){
		canvas.enabled = false;
	}
		
}
