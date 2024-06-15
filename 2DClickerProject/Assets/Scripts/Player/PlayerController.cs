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

    void Start()
    {
        playerAnim = player.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        MouseOnClick();
    }

    public void EnemyAttack(Enemy enemy)
    {
        if (enemy != null)
        {
            Debug.Log("Attacking enemy: " + enemy.name);
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

            if (hit.collider != null && hit.collider.tag == "Enemy")
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                EnemyAttack(enemy);
            }
        }
    }
}

