using System.Numerics;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int stage;
    public int enemyCount;
    public BigInteger gold;
    public BigInteger attackDMG;
    public BigInteger enemyHP;
    

    public GameData(int stage, int enemyCount, BigInteger gold, BigInteger attackDMG, BigInteger enemyHP)
    {
        this.stage = stage;
        this.enemyCount = enemyCount;
        this.gold = gold;
        this.attackDMG = attackDMG;
        this.enemyHP = enemyHP;
    }
}
