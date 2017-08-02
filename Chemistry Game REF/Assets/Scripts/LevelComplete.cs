using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
	private Rigidbody2D rigidbody;
	public List<List<string>> answerList = new List<List<string>>()
	{
		new List<string> { "Carbon" },
		new List<string> { "Hydrogen", "Hydrogen", "Oxygen" },
		new List<string> { "Sodium", "Chlorine" },
		new List<string> { "Helium", "Neon", "Argon", "Krypton" },
		new List<string> { "Carbon", "Carbon", "Hydrogen", "Hydrogen", "Hydrogen", "Hydrogen", "Oxygen" },
		new List<string> { "Carbon", "Carbon", "Hydrogen", "Hydrogen", "Hydrogen", "Hydrogen", "Hydrogen", "Nitrogen", "Oxygen" }
	};
	public List<string> currList = new List<string>();

	//-- text element
	public int score;
	public string loadedname = " ";
	public Text text;
	public Text nametext;
	public int elementCount;
	public bool stopChecking; // Checker to stop checking elements for points after first one is wrong

	// Use this for initialization
	void Start () {
		if (rigidbody == null)
		{
			rigidbody = GetComponent<Rigidbody2D> ();
		}

		if (text == null)
		{
			text = GameObject.Find("score").GetComponent<Text>();
		}

		if (nametext == null)
		{
			nametext = GameObject.Find("playername").GetComponent<Text>();
		}
			
		score = 0;
		elementCount = 0;
		stopChecking = false;
	}

	// Update is called once per frame
	void Update () {
		text.text = "Score : " + PlayerPrefsHelper.getPlayerScore();
		nametext.text = "Player : " + PlayerPrefsHelper.getPlayerName();
	}

	// Check whether the current array of elements matches the answer array
	bool checkArrMatch(List<string> currList, List<string> answerList) {
		if (currList.Count == answerList.Count)
		{
			for (int i = 0; i < currList.Count; i++)
			{
				if (currList [i] != answerList [i]) {
					//reload the level because the compound wasn't correct.
					PlayerPrefsHelper.decreaseScore (2);
					SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
					return false;
				}
			}
			return true;
		}
		return false;
	}

	// Check whether the element collected matches the corrected slot of answer array
	bool checkElmMatch(List<string> currList, List<string> answerList, int elementCount) {
		if (currList [elementCount] == answerList [elementCount]) {
			return true;
		}
		return false;
	}

	void checkifWon() {
		// Get the current level I'm in
		Scene scene = SceneManager.GetActiveScene ();
		string levelStringNum = Regex.Match (scene.name, @"\d+").Value;
		int levelNum = int.Parse (levelStringNum);


		// Gets point only if they get them in order starting from beginning
		bool elementMatches = checkElmMatch (currList, answerList [levelNum - 1], elementCount);

		print (elementMatches);
		print (stopChecking);
		if (elementMatches && !stopChecking) {
			PlayerPrefsHelper.incrementScore (1);
		} else {
			print ("here");
			stopChecking = true;
		}

		// Gets points if the correct element matches correct slot
		// Check if the correct element matches the correct slot get 1 point for correct element
		//bool elementMatches = checkElmMatch (currList, answerList [levelNum - 1], elementCount);
		//if (elementMatches) {
		//	PlayerPrefsHelper.incrementScore (1);
		//}

		// Checks if final answer matches the answer
		bool complete = checkArrMatch (currList, answerList [levelNum - 1]);
		if (complete) {
			PlayerPrefsHelper.incrementScore (5);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("element")) 
		{
			currList.Add (other.gameObject.name);
			checkifWon ();
			elementCount++;
		}
			
	}
}
