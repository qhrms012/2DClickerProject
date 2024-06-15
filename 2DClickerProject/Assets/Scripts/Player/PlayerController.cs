using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    private Animator playerAnim;

    [Header("Audio")]
    public AudioClip attackClip;
    public AudioClip HitClip;
    private AudioSource audiosource;



    // Start is called before the first frame update
    void Start()
    {
        playerAnim = player.GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseOnClick();
    }

   

    private void EnemyAttack(RaycastHit2D hit)
    {
        Enemy enemy = hit.collider.GetComponent<Enemy>();
        AudioSource enemyAudio = hit.collider.GetComponent<AudioSource>();
        if (enemy != null)
        {
            enemy.EnenmyOnClick();
            enemyAudio.clip = HitClip;
            enemyAudio.Play();


            playerAnim.SetTrigger("Attack");
            audiosource.clip = attackClip;
            audiosource.Play();

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
                    EnemyAttack(hit);
                }
            }
        }

    }

