using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public Button increaseAttackButton;
    public TextMeshProUGUI textGold;
    public Button randomGoldButton;

    private Settings settings;

    void Start()
    {
        settings = GameManager.Instance.settings;

        // Increase Attack Button 초기화
        increaseAttackButton.onClick.AddListener(OnIncreaseAttackButtonClicked);

        // Random Gold Button 초기화
        randomGoldButton.onClick.AddListener(OnRandomGoldButtonClicked);
        UpdateGold();
    }

    public void UpdateGold()
    {
        textGold.text = settings.SGold();
    }

    private void OnIncreaseAttackButtonClicked()
    {
        BigInteger attackAmount = 100;
        BigInteger goldCost = 10;

        if (settings.DecreaseGold(goldCost))
        {
            settings.IncreaseAttackDMG(attackAmount);
            UpdateGold();
        }
        else
        {
            Debug.Log("Not enough gold.");
        }
    }
    private void OnRandomGoldButtonClicked()
    {
        BigInteger goldCost = 10;

        if (settings.DecreaseGold(goldCost))
        {
            BigInteger randomGold = (BigInteger)Random.Range(0, 21);
            settings.IncreaseGold(randomGold);
            UpdateGold();
        }
        else
        {
            Debug.Log("Not enough gold.");
        }
    }

}
