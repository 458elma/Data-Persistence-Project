using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour
{
    public static DataSaver Instance;
    public string username;
    public string highscoreName;
    public int highscore;
    private bool isScoreLoaded;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        isScoreLoaded = false;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public bool getIsScoreLoaded()
    {
        return isScoreLoaded;
    }

    [System.Serializable]
    class SaveData
    {
        public string highscoreName;
        public int highscore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highscoreName = highscoreName;
        data.highscore = highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        isScoreLoaded = true;
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscoreName = data.highscoreName;
            highscore = data.highscore;
            isScoreLoaded = true;
        }
    }

    public void ResetHighScore()
    {
        SaveData data = new SaveData();
        data.highscoreName = "Name";
        data.highscore = 0;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        highscoreName = data.highscoreName;
        highscore = data.highscore;
        isScoreLoaded = true;
    }
}
