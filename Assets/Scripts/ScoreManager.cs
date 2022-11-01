using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string CurrentPlayerName;
    public string LastPlayerName;
    public int CurrentPlayerScore;
    public int LastPlayerScore;
    public AudioSource MusicVolume;
    public float SaveMusicVolume;
    
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
        MusicVolume.volume = SaveMusicVolume;
    }

    [System.Serializable]
    public class SaveData
    {
        public string CurrentPlayerName;
        public string LastPlayerName;
        public int CurrentPlayerScore;
        public int LastPlayerScore;
        public float MusicVolume;
    }

    public void SavePlayerScore()
    {
        SaveData data = new SaveData();
        data.CurrentPlayerName = CurrentPlayerName;
        data.CurrentPlayerScore = CurrentPlayerScore;
        data.MusicVolume = SaveMusicVolume;
        data.LastPlayerName = LastPlayerName;
        data.LastPlayerScore = LastPlayerScore;

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

            CurrentPlayerName = data.CurrentPlayerName;
            CurrentPlayerScore = data.CurrentPlayerScore;
            SaveMusicVolume = data.MusicVolume;
            LastPlayerName = data.LastPlayerName;
            LastPlayerScore = data.LastPlayerScore;
        }
    }

    public void ResetData()
    {
        CurrentPlayerName = null;
        CurrentPlayerScore = 0;
        LastPlayerName = null;
        LastPlayerScore = 0;
        SaveMusicVolume = 0.5f;
    }
}
