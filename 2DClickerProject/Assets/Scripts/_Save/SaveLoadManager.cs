using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string saveFileName = "gameData.json";

    public void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(GetSaveFilePath(), json);
        Debug.Log("���� ������ ���� �Ϸ�.");
    }

    public GameData Load()
    {
        string filePath = GetSaveFilePath();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log("���� ������ �ε� �Ϸ�.");
            return data;
        }
        else
        {
            Debug.LogWarning("����� ���� �����Ͱ� �����ϴ�.");
            return null;
        }
    }

    private string GetSaveFilePath()
    {
        return Path.Combine(Application.persistentDataPath, saveFileName);
    }
}
