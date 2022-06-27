using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public int highScore;

    public string highScoreName;

    public string playerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string highScoreName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }



}
