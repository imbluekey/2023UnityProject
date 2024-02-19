using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerMove playermove;
    public GameObject HealthBarBackground;
    public Image HealthBarFilled;

    public GameObject StaminaBarBackground;
    public Image StaminaBarFilled;
    public float maxHp;
    public float nowHp;
    public float maxStamina;
    public float nowStamina;
    public int atk;
    public int def;

    public bool staminaUsed = false;
    float staminaTime;
    float needToRest = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        playermove = GetComponent<PlayerMove>();

        nowHp = maxHp;
        nowStamina = maxStamina;
        HealthBarFilled.fillAmount = 1f;
        StaminaBarFilled.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timeStamina();
        recoverStamina();
        StaminaBarFilled.fillAmount = nowStamina / maxStamina;
    }
    public void getDamaged(int damage)
    {
        //contemporary
        Debug.Log("get" + (damage - def) + "damage");
        nowHp -= (damage-def);
        Debug.Log(nowHp / maxHp);
        HealthBarFilled.fillAmount = nowHp / maxHp;
    }
    public void useStamina(float Stamina)
    {
        staminaUsed = true;
        staminaTime = needToRest;
        if (nowStamina == 0)
        {
            playermove.canActive = false;
            staminaTime = 5f;
            StartCoroutine(WhenStaminaZero());
            return;
        }
            if (nowStamina != 0)
        {
            
            if (nowStamina - Stamina > 0)
            {
                nowStamina -= Stamina;
            }
            else if (nowStamina - Stamina <= 0)
            {
                nowStamina = 0;
            }
        }
    }
    private void timeStamina()
    {
        if ( staminaUsed )
        {
            if(staminaTime > 0f)
            {
                staminaTime -= Time.deltaTime;
            }
            else if (staminaTime <= 0f)
            {
                staminaTime = 0f;
                staminaUsed = false;
            }
        }
    }
    private void recoverStamina()
    {
        if((!staminaUsed) && (nowStamina < maxStamina) && (staminaTime <= 0))
        {
            nowStamina += 0.1f;
            if(nowStamina > maxStamina)
            {
                nowStamina = maxStamina;
            }
        }
    }
    IEnumerator WhenStaminaZero()
    {
        yield return new WaitForSeconds(5f);
        playermove.canActive = true;
    }
}
