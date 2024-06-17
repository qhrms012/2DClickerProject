using System.Numerics;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public BigInteger attackDMG = 10;
    public BigInteger enemyHP = 100;
    private BigInteger newEnemyHP;

    public BigInteger gold = 30;
    public BigInteger payGold = 1;
    private BigInteger dropGold = 1;

    public int stage = 1;
    public int enemyCount = 6;

    void Start()
    {
        newEnemyHP = enemyHP;
    }

    public bool IsEnemyDie()
    {
        bool result = false;
        enemyHP -= attackDMG;

        if (enemyHP <= 0)
        {
            enemyHP = 0;
            result = true;
            gold += dropGold; // ÀûÀÌ Á×À» ¶§ °ñµå È¹µæ
        }

        return result;
    }

    public void InitEnemyHP()
    {
        BigInteger hp = (BigInteger)((float)enemyHP * 1.8f);
        enemyHP = hp;
        newEnemyHP = enemyHP;
    }

    public void GetEnemyHP()
    {
        enemyHP = newEnemyHP;
    }
    public BigInteger GetCurrentEnemyHP()
    {
        return enemyHP;
    }
    public BigInteger GetMaxEnemyHP()
    {
        return newEnemyHP;
    }


    public BigInteger GetGold()
    {
        dropGold = BigInteger.Pow(2, stage) / 2;
        if (dropGold < 1)
        {
            dropGold = 1;
        }
        gold += dropGold;
        return gold;
    }

    public float GetEnemyHpUI()
    {
        return (float)enemyHP / (float)newEnemyHP;
    }

    private string FormatNum(BigInteger num)
    {
        string[] unit = { "", "K", "M", "Y", "T" };
        int unitIndex = 0;

        while (num > 1000 && unitIndex < unit.Length - 1)
        {
            num /= 1000;
            unitIndex++;
        }
        return string.Format("{0}{1}", num, unit[unitIndex]);
    }

    public string SGold()
    {
        return FormatNum(gold);
    }
    public void IncreaseAttackDMG(BigInteger amount)
    {
        attackDMG += amount;
    }
    public bool DecreaseGold(BigInteger amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            return true;
        }
        return false;
    }
    public void IncreaseGold(BigInteger amount)
    {
        gold += amount;
    }
    public BigInteger GetAttackDMG()
    {
        return attackDMG;
    }
}
