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
    public float maxhp;
    public float nowhp;
    public GameObject SuperObject;
    // Start is called before the first frame update
    void Start()
    {
        //it will be changed when monster object coded.
        maxhp = 100;
        nowhp = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        // + code plus
        // need object of monster or etc
        // we will show hpBar only if monster object Exist
        HPImage.fillAmount = (float)nowhp / (float)maxhp;
        if (Input.GetKeyDown(KeyCode.H))
        {
            nowhp = nowhp - (float)10;
        }
    }
}