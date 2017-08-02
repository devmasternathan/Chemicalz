using UnityEngine;
using System.Collections;

public class gameControl : MonoBehaviour {

	public string playerName;
	public int score;

	public static gameControl Instance;

	// Use this for initialization
	void Start () {
		playerName = "";
		score = 0;
	}

	void Awake()
	{
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	public void setScore(int s)
	{
		score = s;
	}

	public int getScore()
	{
		return score;
	}

	public void setName(string n)
	{
		playerName = n;
	}

	public string getName()
	{
		return playerName;
	}

	public void increaseScore (int a)
	{
		score += a;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
