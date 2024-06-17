using System.Collections;
using UnityEngine;

public class EnemySp : MonoBehaviour
{
    [Header("Enemy")]
    public GameObject[] enemies;
    public GameObject enemySpawn;
    public bool isSpawn = true;

    private Settings settings;
    private UIcontroller controller;

    private void Start()
    {
        settings = GameManager.Instance.settings;
        controller = FindObjectOfType<UIcontroller>();
    }

    void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        if (isSpawn)
        {
            StartCoroutine(EnemySpawnTime());
            isSpawn = false;
        }
    }

    IEnumerator EnemySpawnTime()
    {
        yield return new WaitForSeconds(1f);

        if (settings.enemyCount <= 0)
        {
            settings.stage += 1;
            settings.enemyCount = 6;
            settings.InitEnemyHP();
            controller.UpdateStageCount(settings.stage);  // 스테이지 카운트 업데이트
        }

        int ran = Random.Range(0, enemies.Length);
        Instantiate(enemies[ran], enemySpawn.transform.position, Quaternion.identity);
        settings.enemyCount -= 1; // 적의 수를 감소
        controller.UpdateEnemyCount(settings.enemyCount); // 적의 수 UI 업데이트
    }
}
