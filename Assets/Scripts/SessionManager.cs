using UnityEngine;
using System.IO;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;
    public string playerName;
    public int bestScore;
    void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance=this;
        DontDestroyOnLoad(Instance);

        LoadPlayerData();           
    }


    [System.Serializable]
    public class SavePlayerData
    {
        public string Name;
        public int BestScore;
    }

    public void SaveData(int score)
    {
        SavePlayerData data = new SavePlayerData();

        data.Name = playerName;
        data.BestScore= score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath+"/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavePlayerData data = JsonUtility.FromJson<SavePlayerData>(json);
            playerName=data.Name;
            bestScore=data.BestScore;
        }
    }
}
