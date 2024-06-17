using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    private Animator playerAnim;

    [Header("Audio")]
    public AudioClip attackClip;
    public AudioClip hitClip;
    private AudioSource audioSource;

    private UIcontroller uicontroller;
    private Settings settings;

    void Start()
    {
        playerAnim = player.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        settings = GameManager.Instance.settings;
        uicontroller = FindObjectOfType<UIcontroller>();
    }

    void Update()
    {
        MouseOnClick();
    }

    public void EnemyAttack(Enemy enemy)
    {
        if (enemy != null)
        {
            enemy.EnenmyOnClick();
            AudioSource enemyAudio = enemy.GetComponent<AudioSource>();
            if (enemyAudio != null)
            {
                enemyAudio.clip = hitClip;
                enemyAudio.Play();
            }

            playerAnim.SetTrigger("Attack");
            audioSource.clip = attackClip;
            audioSource.Play();

            if (settings != null && settings.IsEnemyDie())
            {
                enemy.EnemyDie();
                settings.GetGold();
                if (uicontroller != null)
                {
                    uicontroller.textGold.text = settings.SGold();
                }

                settings.GetEnemyHP();

                if (GameManager.Instance.enemySp != null)
                {
                    GameManager.Instance.enemySp.isSpawn = true;
                }
                else
                {
                    Debug.LogError("EnemySp 객체를 찾을 수 없습니다.");
                }
            }
        }
        else
        {
            Debug.Log("No enemy found to attack.");
        }
    }

    private void MouseOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                EnemyAttack(enemy);
            }
        }
    }
}

