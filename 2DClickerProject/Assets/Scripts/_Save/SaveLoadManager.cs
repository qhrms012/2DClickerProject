using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string saveFileName = "gameData.json";

    public void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(GetSaveFilePath(), json);
        Debug.Log("게임 데이터 저장 완료.");
    }

    public GameData Load()
    {
        string filePath = GetSaveFilePath();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log("게임 데이터 로드 완료.");
            return data;
        }
        else
        {
            Debug.LogWarning("저장된 게임 데이터가 없습니다.");
            return null;
        }
    }

    private string GetSaveFilePath()
    {
        return Path.Combine(Application.persistentDataPath, saveFileName);
    }
}
