using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Settings settings; // ���� ���� ��ü
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
            // �ε�� �����͸� ���ӿ� �ݿ�
            settings.stage = loadedData.stage;
            settings.enemyCount = loadedData.enemyCount;
            settings.gold = loadedData.gold;
            settings.attackDMG = loadedData.attackDMG;
            settings.enemyHP = loadedData.enemyHP;

            // ��Ÿ UI ���� ������Ʈ �۾�
            UpdateUI();
        }
        else
        {
            // ���ο� ���� ���� �� �ʱ�ȭ �Ǵ� ��Ÿ ó��
            Debug.Log("���ο� ���� ����.");
        }
    }

    private void UpdateUI()
    {
        // UI ������Ʈ ���� �߰�
    }
}
