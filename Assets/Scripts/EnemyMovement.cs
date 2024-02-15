using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;


public class EnemyMovement : MonoBehaviour
{
    public AIPath aIPath;
    public Transform player;
    public Transform boxpos;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    Vector2 direction;
    public Vector2 boxSize;

    bool fliped;
    bool hitted;
    bool onAttack;
    float distance;

    public GameObject HealthBarBackground;
    public Image HealthBarFilled;

    public float maxHp;
    public float nowHp;
    public int attack;
    public int defense;
    public float speed;
    float chaseRange = 20f;
    float attackRange = 6f;
    float attackDelay = 1.75f;
    float delay;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        aIPath.maxSpeed = speed;
        HealthBarFilled.fillAmount = 1f;

        nowHp = maxHp;
        HealthBarBackground.SetActive(false);
        hitted=false;
        onAttack = false;
        delay = attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay < 0) delay = 0;
        distance = Vector2.Distance(player.transform.position, transform.position);
        if ((hitted))
        {
            //add code about stun motion is considered by arrow's damage
            //if(damage>tmp)
            animator.SetInteger("State", 3);
            hitted = false;
            chaseRange = 500f;
            //keep attack when hitted
            //if ((distance < attackRange))
            //{
            //   onAttack = true;
            //    animator.SetInteger("State", 2);
            //    animator.SetBool("isWalking", false);
            //    //Debug.Log("attacking");
            //}
        }
        else
        {
            if ((distance < chaseRange))
            {
                animator.SetBool("isWalking", false);
                if ((distance < attackRange)&& delay == 0)
                {
                    animator.SetInteger("State", 2);
                    animator.SetBool("isWalking", false);
                    delay = attackDelay;
                    //Debug.Log("attacking");
                }
                else if ((distance < attackRange))
                {
                    animator.SetInteger("State", 0);
                    animator.SetBool("isWalking", false);
                    aIPath.canMove = false;
                }
                else
                {
                    if (!onAttack)
                    {
                        animator.SetInteger("State", 0);
                        animator.SetBool("isWalking", true);
                        aIPath.canMove = true;
                    }
                    //Debug.Log("chasing");
                }
            }
            else
            {
                animator.SetInteger("State", 0);
                animator.SetBool("isWalking", false);
                aIPath.canMove = false;
                //Debug.Log("idle");
            }
        }
       if (player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
            //Debug.Log("Mob<Player");
        }
        else if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
            //Debug.Log("Player<Mob");
        }
        fliped = spriteRenderer.flipX;
        Debug.Log(onAttack);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { //when the arrow collise with the objects....
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "BasicArrow(Clone)")
        {
            hitted = true;
            nowHp -= 10f;
            if (nowHp <= 0f)
            {
                animator.SetInteger("State", 3);
                Destroy(this.gameObject);
                Destroy(this.HealthBarBackground);
            }
            HealthBarFilled.fillAmount = nowHp / maxHp;
            HealthBarBackground.SetActive(true);
        }
    }
    public void Attack()
    {

    }
    public void AttackStart()
    {
        onAttack = true;
    }
    public void AttackEnd() 
    {
        onAttack = false;
    }
}