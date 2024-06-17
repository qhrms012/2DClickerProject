using System.Collections;
using UnityEngine;

public class AutoClickController : MonoBehaviour
{
    public PlayerController playerController; // PlayerController를 참조

    [Header("Auto Click Settings")]
    public float clickInterval = 1f;
    public float attackRange = 5f;
    private bool isAutoClicking = false;

    private void Start()
    {
        // 자동 클릭 시작
        StartCoroutine(AutoClick());
    }

    private IEnumerator AutoClick()
    {
        while (true)
        {
            if (isAutoClicking)
            {
                // 주변의 적을 찾아 공격
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
                break; // 한 번 공격 후 종료
            }
        }
    }

    public void ToggleAutoClicking()
    {
        isAutoClicking = !isAutoClicking;
        if (isAutoClicking)
        {
            Debug.Log("오토 시작");
        }
        else
        {
            Debug.Log("오토 종료");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerController.transform.position, attackRange);
    }
}
