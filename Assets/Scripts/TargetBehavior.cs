using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public float TargetHealthPoint = 50f;
    public GameObject HealthPointBar;
    private HpBar hpBar;
    //private RectTransform hpBarRectTransform;

    // Start is called before the first frame update
    void Start()
    {
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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{ //when the arrow collise with the objects....
    //    Debug.Log("ArrowTarget collides with the objects . . . ");
    //    Debug.Log(collision.gameObject.name);
    //    if (collision.gameObject.name == "BasicArrow(Clone)")
    //    {
    //        hpBar.decreaseHp(10f);
    //        TargetHealthPoint -= 10f;
    //    }
    //}

}
