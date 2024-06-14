using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseOnClick();
    }


    private void MouseOnClick()
    {
        if(Input.GetMouseButtonDown(0))
        { 
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if(hit.collider != null && hit.collider.tag == "Enemy")
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                
                if (enemy != null)
                {
                    enemy.EnenmyOnClick();                   
                    playerAnim.SetTrigger("Attack");
                }
            }
        }
    }

}
