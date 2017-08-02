using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DataScript : MonoBehaviour {
	/*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class ScoreKeeper
{
    string name;
    int score;

    public void savingdata(int score, string playername)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");

        ScoreData data = new ScoreData();
        data.score = score;
        data.name = playername;

        bf.Serialize(file, data);
        file.Close();
    }

    public void loadingdata()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            ScoreData data = (ScoreData)bf.Deserialize(file);
            file.Close();
            score = data.score;
            name = data.name;
        }
    }

    public string getName()
    {
        return name;
    }

    public int getScore()
    {
        return score;
    }
}

[System.Serializable]
public class ScoreData
{
    public int score;
    public string name;
}
*/}