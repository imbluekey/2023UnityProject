using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    //read monster object's name,hp(=status) and apply their stat on Hpbar
    //then each monster get their own hp bar prefeb(maybe)
    //so we can get each monster's hp stat..
    public Image HPImage;
    private float maxhp;
    private float nowhp;


    public void setMaxHp(float hp)
    {
        maxhp = hp;
        nowhp = hp;
    }

    public void decreaseHp(float damage)
    {
        Debug.Log("Decreasing HP of the target.");
        nowhp -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // + code plus
        // need object of monster or etc
        // we will show hpBar only if monster object Exist
        HPImage.fillAmount = (float)nowhp / (float)maxhp;
    }
}