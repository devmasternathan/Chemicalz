using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class LevelComplete : MonoBehaviour
{
    /*
	private Rigidbody2D rigidbody;
	public List<List<string>> answerList = new List<List<string>>()
	{
		new List<string> { "Carbon" },
		new List<string> { "Hydrogen", "Hydrogen", "Oxygen" },
		new List<string> { "Sodium", "Chlorine" },
		new List<string> { "Helium", "Neon", "Argon", "Krypton" }
	};
	public List<string> currList = new List<string>();

	// Use this for initialization
	void Start () {
		if (rigidbody == null)
		{
			rigidbody = GetComponent<Rigidbody2D> ();
		}
	}

	// Update is called once per frame
	void Update () {
		checkifWon ();
	}

	bool checkArrMatch(List<string> currList, List<string> answerList) {
		if (currList.Count == answerList.Count)
		{
			for(int i = 0; i < currList.Count; i++)
			{
				if(currList[i] != answerList[i])
				{
					//reload the level because the compound wasn't correct.
					SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
					return false;
				}
			}
			return true;
		}
		return false;
	}

	void checkifWon() {
		// Get the current level I'm in
		Scene scene = SceneManager.GetActiveScene ();
		string levelStringNum = Regex.Match (scene.name, @"\d+").Value;
		int levelNum = int.Parse (levelStringNum);
		bool complete = checkArrMatch (currList, answerList [levelNum - 1]);
		if (complete) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("element")) 
		{
			currList.Add (other.gameObject.name);
		}
			
	}
    */
}
