using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBehavior : MonoBehaviour
{
    public Rigidbody2D mobRigidbody;
    private SpriteRenderer mobSprite;
    private Animator mobAnimator;
    public Transform player;

    public float Atk;
    public float Def;
    public float MaxHealthPoint;
    public float CurrentHealthPoint;
    bool isDamaged;

    public float atkCooltime;
    public float atkDelay;
    bool isAttacking;
    bool isMoving;
    bool fliped;

    public float speed = 0.5f;
    float distance;

    public GameObject HealthBarBackground;
    public Image HealthBarFilled;

    //private RectTransform hpBarRectTransform;
    Vector2 mobPos;
    // Start is called before the first frame update

    void Start()
    {
        mobSprite = GetComponent<SpriteRenderer>();
        mobAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CurrentHealthPoint = MaxHealthPoint;

        HealthBarFilled.fillAmount = 1f;
        atkDelay = 1;
        isDamaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealthPoint < MaxHealthPoint)
        {
            isDamaged = true;
        }
        fliped = mobSprite.flipX;
        if(atkDelay >= 0)
        {
            atkDelay -= Time.deltaTime;
        }

        mobPos = transform.position;
        distance = Vector2.Distance(player.transform.position, mobPos);
        if (!isAttacking)
        {
            isMoving = Movements(mobPos, distance);
        }
        if (!isMoving)
        {
            if (atkDelay <= 0)
            {
                if (distance < 1)
                {
                    isAttacking = true;
                    mobAnimator.SetTrigger("Attack");
                    atkDelay = 1;
                    StartCoroutine(WaitCoroutine(distance));
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { //when the arrow collise with the objects....
        string collisionObjectName = collision.gameObject.name;
        Debug.Log("Slime Behavior : " + collisionObjectName);
        if(ObjectNameDetection.HasString(collisionObjectName, "Arrow"))
        {
            ArrowControl HitArrow = collision.gameObject.GetComponent<ArrowControl>();
            float damage = HitArrow.getArrowDamage();
            Debug.Log("Slime Behavior : Damage by the arrow : " + damage);
            bool getDamage = HitArrow.getGiveDamage();
            if (getDamage == true) { 
                //get damaged when hit by an arrow for only once.
                CurrentHealthPoint -= damage;
            }
            if (CurrentHealthPoint <= 0f)
            {
                Destroy(this.gameObject);
                Destroy(this.HealthBarBackground);
            }
            HealthBarFilled.fillAmount = CurrentHealthPoint / MaxHealthPoint;
            HealthBarBackground.SetActive(true);
        }
    }
    bool Movements(Vector2 mobPos, float distance)
    {
        if (player.transform.position.x > mobPos.x)
        {
            mobSprite.flipX = true;
            //Debug.Log("Mob<Player");
        }
        else if (player.transform.position.x < mobPos.x)
        {
            mobSprite.flipX = false;
            //Debug.Log("Player<Mob");
        }
        if (distance <= 4 && distance >= 1)
        {
            mobAnimator.SetBool("Following", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            //Debug.Log("Following");
            return true;
        }
        else if(distance <1)
        {
            mobRigidbody.velocity = Vector3.zero;
            mobAnimator.SetBool("Following", false);
            return false;
        }
        else
        {
            mobRigidbody.velocity = Vector3.zero;
            if (isDamaged)
            {
                mobAnimator.SetBool("Following", true);
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                return true;
            }
            else
            {
                mobAnimator.SetBool("Following", false);
                return false;
            }
        }
    }

    IEnumerator WaitCoroutine(float distance)
    {
        yield return new WaitForSeconds(3f);
        if (distance < 1)
        {
            Debug.Log("slime attack");
        }
    }

    public void Attack()
    {
        if (fliped == true)
        {
            //right direction
        }
        else if(fliped == false)
        {
            //left direction
        }
        //add condition...
        Debug.Log("Slime Damages character :" + Atk);
    }
    public void AttackEnd()
    {
        isAttacking = false;
    }
}