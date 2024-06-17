using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Settings settings; // 게임 설정 객체
    public SaveLoadManager saveLoadManager;

    private void Start()
    {
        saveLoadManager = GetComponent<SaveLoadManager>();
        LoadGameData();
    }

    public void SaveGameData()
    {
        GameData data = new GameData(settings.stage, settings.enemyCount, settings.gold, settings.attackDMG, settings.enemyHP);
        saveLoadManager.Save(data);
    }

    public void LoadGameData()
    {
        GameData loadedData = saveLoadManager.Load();
        if (loadedData != null)
        {
            // 로드된 데이터를 게임에 반영
            settings.stage = loadedData.stage;
            settings.enemyCount = loadedData.enemyCount;
            settings.gold = loadedData.gold;
            settings.attackDMG = loadedData.attackDMG;
            settings.enemyHP = loadedData.enemyHP;

            // 기타 UI 등의 업데이트 작업
            UpdateUI();
        }
        else
        {
            // 새로운 게임 시작 시 초기화 또는 기타 처리
            Debug.Log("새로운 게임 시작.");
        }
    }

    private void UpdateUI()
    {
        // UI 업데이트 로직 추가
    }
}
