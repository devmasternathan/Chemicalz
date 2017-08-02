using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class displayHighScore : MonoBehaviour {

	private Text p1, p2, p3, p4, p5;
	private Text s1, s2, s3, s4, s5;

	// Use this for initialization
	void Start () {
		p1 = GameObject.Find ("Player1").GetComponent<Text> ();
		p2 = GameObject.Find ("Player2").GetComponent<Text> ();
		p3 = GameObject.Find ("Player3").GetComponent<Text> ();
		p4 = GameObject.Find ("Player4").GetComponent<Text> ();
		p5 = GameObject.Find ("Player5").GetComponent<Text> ();
		s1 = GameObject.Find ("Score1").GetComponent<Text> ();
		s2 = GameObject.Find ("Score2").GetComponent<Text> ();
		s3 = GameObject.Find ("Score3").GetComponent<Text> ();
		s4 = GameObject.Find ("Score4").GetComponent<Text> ();
		s5 = GameObject.Find ("Score5").GetComponent<Text> ();

		p1.text = PlayerPrefs.GetString ("P1");
		p2.text = PlayerPrefs.GetString ("P2");
		p3.text = PlayerPrefs.GetString ("P3");
		p4.text = PlayerPrefs.GetString ("P4");
		p5.text = PlayerPrefs.GetString ("P5");
		s1.text = PlayerPrefs.GetInt ("S1").ToString ();
		s2.text = PlayerPrefs.GetInt ("S2").ToString ();
		s3.text = PlayerPrefs.GetInt ("S3").ToString ();
		s4.text = PlayerPrefs.GetInt ("S4").ToString ();
		s5.text = PlayerPrefs.GetInt ("S5").ToString ();

		setDisplay ();
	}

	public void setDisplay(){
		if (PlayerPrefs.GetInt ("S1") == 0 && (PlayerPrefs.GetString ("P1") == "???" || PlayerPrefs.GetString ("P1") == "")) {
			p1.text = "--";
			s1.text = "--";
		}
		if (PlayerPrefs.GetInt ("S2") == 0 && (PlayerPrefs.GetString ("P2") == "???" || PlayerPrefs.GetString ("P2") == "")) {
			p2.text = "--";
			s2.text = "--";
		}
		if (PlayerPrefs.GetInt ("S3") == 0 && (PlayerPrefs.GetString ("P3") == "???"|| PlayerPrefs.GetString ("P3") == "")) {
			p3.text = "--";
			s3.text = "--";
		}
		if (PlayerPrefs.GetInt ("S4") == 0 && (PlayerPrefs.GetString ("P4") == "???" || PlayerPrefs.GetString ("P4") == "")) {
			p4.text = "--";
			s4.text = "--";
		}
		if (PlayerPrefs.GetInt ("S5") == 0 && (PlayerPrefs.GetString ("P5") == "???" || PlayerPrefs.GetString ("P5") == "")) {
			p5.text = "--";
			s5.text = "--";
		}
	}
	public void resetHighScores(){
		PlayerPrefs.SetInt("S1", 0);
		PlayerPrefs.SetString("P1","???");
		PlayerPrefs.SetInt("S2", 0);
		PlayerPrefs.SetString("P2","???");
		PlayerPrefs.SetInt("S3", 0);
		PlayerPrefs.SetString("P3","???");
		PlayerPrefs.SetInt("S4", 0);
		PlayerPrefs.SetString("P4","???");
		PlayerPrefs.SetInt("S5", 0);
		PlayerPrefs.SetString("P5","???");

		setDisplay ();
	}
	// Update is called once per frame
	//void Update () {}
}
