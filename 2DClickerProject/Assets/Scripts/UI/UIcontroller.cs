using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [Header("UI")]
    public Image imageEnemyHP;
    public TextMeshProUGUI textGold;
    public TextMeshProUGUI StageCount;
    public TextMeshProUGUI enemyCount;
    public TextMeshProUGUI textenemyHP;
    public TextMeshProUGUI textAttackDMG;
    public Button increaseAttackButton;

    private Settings settings;
    private ShopManager shopManager;

    void Start()
    {
        settings = GameManager.Instance.settings;
        shopManager = FindObjectOfType<ShopManager>();
        UpdateGold();
        textGold.text = settings.SGold();
        StageCount.text = settings.stage.ToString();
        enemyCount.text = settings.enemyCount.ToString();
    }

    void Update()
    {
        ShowEnemyHP();
        UpdateEnemyHP();
        UpdateAttackDMG();
    }

    private void ShowEnemyHP()
    {
        if (settings != null)
        {
            imageEnemyHP.fillAmount = settings.GetEnemyHpUI();
        }
    }

    public void UpdateStageCount(int stage)
    {
        StageCount.text = stage.ToString();
    }

    public void UpdateEnemyCount(int count)
    {
        enemyCount.text = count.ToString();
    }

    public void UpdateGold()
    {
        textGold.text = settings.SGold();
    }
    public void UpdateEnemyHP()
    {
        if (settings != null)
        {
            textenemyHP.text = settings.GetCurrentEnemyHP().ToString() + " / " + settings.GetMaxEnemyHP().ToString();
        }
    }
    public void UpdateAttackDMG()
    {
        if (settings != null)
        {
            textAttackDMG.text = "현재 공격력 : " + settings.GetAttackDMG().ToString();
        }
    }
}
