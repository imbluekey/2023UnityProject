using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject HealthBarBackground;
    public Image HealthBarFilled;

    public float maxHp;
    public float nowHp;
    public float maxStamina;
    public float nowStamina;
    public int atk;
    public int def;

    // Start is called before the first frame update
    void Start()
    {
        nowHp = maxHp;
        nowStamina = maxStamina;
        HealthBarFilled.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getDamaged(int damage)
    {
        //contemporary
        Debug.Log("get" + (damage - def) + "damage");
        nowHp -= (damage-def);
        Debug.Log(nowHp / maxHp);
        HealthBarFilled.fillAmount = nowHp / maxHp;
    }
}
