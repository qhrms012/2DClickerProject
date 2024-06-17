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
        StartCoroutine(AutoClick());
    }

    private IEnumerator AutoClick()
    {
        while (true)
        {
            if (isAutoClicking)
            {
                // �ֺ��� ���� ã�� ����
                AttackNearbyEnemies();
            }

            yield return new WaitForSeconds(clickInterval);
        }
    }

    private void AttackNearbyEnemies()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(playerController.transform.position, attackRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                Enemy enemy = hitCollider.GetComponent<Enemy>();
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
