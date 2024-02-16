using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetBehavior : MonoBehaviour
{
    public float TargetAtk;
    public float TargetDef;
    public float TargetMaxHealthPoint;
    public float TargetCurrentHealthPoint;

    public GameObject HealthBarBackground;
    public Image HealthBarFilled;
    public float MaxHealthPoint;
    public float CurrentHealthPoint;



    //private RectTransform hpBarRectTransform;

    // Start is called before the first frame update
    void Start()
    {
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
        if (ObjectNameDetection.HasString(collision.gameObject.name, "Arrow"))
        {
            ArrowControl HitArrow = collision.gameObject.GetComponent<ArrowControl>();
            float damage = HitArrow.getArrowDamage();
            Debug.Log("Slime Behavior : Damage by the arrow : " + damage);
            bool getDamage = HitArrow.getGiveDamage();
            if (getDamage == true)
            {
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

}
