using System.Collections;
using UnityEngine;

public class AutoClickController : MonoBehaviour
{
    public PlayerController playerController; // PlayerController�� ����

    [Header("Auto Click Settings")]
    public float clickInterval = 1f;
    public float attackRange = 5f;
    private bool isAutoClicking = false;

    private void Start()
    {
        // �ڵ� Ŭ�� ����
        Debug.Log("Starting AutoClick Coroutine.");
        StartCoroutine(AutoClick());
    }

    private IEnumerator AutoClick()
    {
        Debug.Log("AutoClick Coroutine started.");
        while (true)
        {
            if (isAutoClicking)
            {
                Debug.Log("AutoClick triggered.");
                // �ֺ��� ���� ã�� ����
                AttackNearbyEnemies();
            }

            yield return new WaitForSeconds(clickInterval);
        }
    }

    private void AttackNearbyEnemies()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(playerController.transform.position, attackRange);
        Debug.Log("Checking for enemies in range: " + hitColliders.Length + " found.");
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                Enemy enemy = hitCollider.GetComponent<Enemy>();
                Debug.Log("Enemy found: " + enemy.name);
                playerController.EnemyAttack(enemy);
                break; // �� �� ���� �� ����
            }
        }
    }

    public void ToggleAutoClicking()
    {
        isAutoClicking = !isAutoClicking;
        if (isAutoClicking)
        {
            Debug.Log("���� ����");
        }
        else
        {
            Debug.Log("���� ����");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerController.transform.position, attackRange);
    }
}
