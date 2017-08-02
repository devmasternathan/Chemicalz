using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class highScoreKeeper : MonoBehaviour {
	/*
	const int NUM_SCORES = 5;

	// Use this for initialization
	/*void Start () {

		int pScore = gameControl.Instance.getScore ();

		string scoreKey = "HighScore";

		for (int i = 0; i < NUM_SCORES; i++) {
			string curScoreKey = (scoreKey + i).ToString ();
		
			if (!(PlayerPrefs.HasKey (curScoreKey))) {
				print ("no such score");
				PlayerPrefs.SetInt (curScoreKey, pScore);
			} 
			else {
				int score = PlayerPrefs.GetInt (curScoreKey);

				if (pScore > score) {
					int tempScore = score;

					PlayerPrefs.SetInt (curScoreKey, pScore);

					pScore = tempScore;
				}
			}
		}

	}*/
	
	// Update is called once per frame
	void Update () {
		
	}
}
