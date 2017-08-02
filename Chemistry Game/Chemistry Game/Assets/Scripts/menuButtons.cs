using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuButtons : MonoBehaviour {

	public void preGame(){
		SceneManager.LoadScene ("preGameSetup");
	}

	public void PlayGame(){
		SceneManager.LoadScene("Level 1");
	}
	public void loadOptions(){
		SceneManager.LoadScene ("options");
	}
	//quit the game, exit window
	public void QuitGame(){
		Application.Quit ();
		PlayerPrefs.Save ();
	}
	public void saveScores(){
		SceneManager.LoadScene ("savingScene");
	}
	//loads main menu screen.
	public void mainMenu(){
		SceneManager.LoadScene ("menu");
	}
	public void highScores()
	{
		SceneManager.LoadScene ("highScore");
	}

	public void nextScene() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	} 
}
