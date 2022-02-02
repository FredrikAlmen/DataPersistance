using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManagerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainManagerMenu Instance;
    public string playerName;
    public string playerNameHighScore;
    public int highScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveHighScore(int scoreFromGame)
    {
        Debug.Log("im outside save highscore");
        SaveData data = new SaveData();
        if (CheckHigScore() < scoreFromGame)
        {  
            Debug.Log("im in save highscore");
            data.highScore = scoreFromGame;
            data.playerName = playerName;
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        
    }

    public void LoadHighScore()
    {
        Debug.Log("im in load highscore outside if");
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("im in load highscore");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            playerNameHighScore = data.playerName;
        }
        else
        {
            File.Create(Application.persistentDataPath + "/savefile.json");
        }
    }

    public int CheckHigScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("im in check highscore");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            return data.highScore;
        }

        return 0;
    }

    public void ResetHighScore()
    {
        SaveData data = new SaveData();

            data.highScore = 0;
            data.playerName = "";
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
       

    }


}
