using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TargetBehavior : MonoBehaviour
{
    private Rigidbody2D mobRigidbody;
    private SpriteRenderer mobSprite;
    private Animator mobAnimator;

    public Transform player;

    public float TargetAtk;
    public float TargetDef;
    public float TargetMaxHealthPoint;
    public float TargetCurrentHealthPoint;

    public float speed = 0f;

    public GameObject HealthBarBackground;
    public Image HealthBarFilled;

    Vector3 mobPos;
    //private RectTransform hpBarRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        mobRigidbody = GetComponent<Rigidbody2D>();
        mobSprite = GetComponent<SpriteRenderer>();
        mobAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        TargetCurrentHealthPoint = TargetMaxHealthPoint;

        HealthBarFilled.fillAmount = 1f;
        //hpBar = HealthPointBar.GetComponent<HpBar>();
        //hpBar.setMaxHp(TargetHealthPoint);
        //hpBarRectTransform = Instantiate(hpBar).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    { 
        //if(hpBarRectTransform == null)
        //{
        //    Debug.Log("RectTransform is null pointer");
        //}
        //if(TargetHealthPoint <= 0)
        //{
        //    gameObject.SetActive(false); 
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { //when the arrow collise with the objects....
        Debug.Log("ArrowTarget collides with the objects . . . ");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "BasicArrow(Clone)")
        {
            TargetCurrentHealthPoint -= 10f;
            if(TargetCurrentHealthPoint <= 0f)
            {
                Destroy(this.gameObject);
                Destroy(this.HealthBarBackground);
            }
            HealthBarFilled.fillAmount = TargetCurrentHealthPoint / TargetMaxHealthPoint;
            HealthBarBackground.SetActive(true);
        }
    }

}
