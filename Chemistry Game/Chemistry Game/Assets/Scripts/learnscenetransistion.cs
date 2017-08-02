using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class learnscenetransistion : MonoBehaviour
{
	// go to next screen.
	public void nextButton ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
	
	// go to previous screen.
	public void previousButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // go to menu.
    public void menuButton()
    {
        SceneManager.LoadScene("menu");
    }

    //-- go to enter text screen.
    public void startGameButton()
    {
        SceneManager.LoadScene(3);
    }
}
