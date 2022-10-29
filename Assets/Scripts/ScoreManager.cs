using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string PlayerName;
    public int PlayerScore;
    public AudioSource MusicVolume;
    public float SaveVolume;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        MusicVolume = GetComponent<AudioSource>();
        
        LoadPlayerScore();
    }

    public void Update()
    {
        MusicVolume.volume = SaveVolume;
    }

    [System.Serializable]
    public class SaveData
    {
        public string Name;
        public int Score;
        public float Volume;
    }

    public void SavePlayerScore()
    {
        SaveData data = new SaveData();
        data.Name = PlayerName;
        data.Score = PlayerScore;
        data.Volume = SaveVolume;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadPlayerScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.Name;
            PlayerScore = data.Score;
            SaveVolume = data.Volume;
        }
    }
}
