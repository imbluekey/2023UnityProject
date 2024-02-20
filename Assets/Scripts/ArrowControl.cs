using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{

    public float ArrowDisappearTime = 5.0f;
    public float ArrowDamage = 1f;
    private Rigidbody2D ArrowRigidbody;
    private Vector3 ArrowVector;
    public bool ArrowFire = false;
    private bool ArrowCollides = false;
    private bool giveDamage;
    private string collisionObjectName;
    private bool i = true;

    public float getArrowDamage()
    {
        return ArrowDamage;
    }

    public void setArrowDamage(float damage)
    {
        ArrowDamage = damage;
    }

    public bool getGiveDamage()
    {
        return giveDamage;
    }

    public void setGiveDamage(bool give)
    {
        giveDamage = give;
    }

    public void UnactivateArrow()
    {
        gameObject.SetActive(false);
        giveDamage = false;
        ArrowFire = false;
        gameObject.transform.position = Vector3.zero;
        ArrowRigidbody.velocity = Vector3.zero;
        collisionObjectName = "";

    }

    public void ActivateArrow()
    {
        gameObject.SetActive(true);
        ArrowFire = false;
        ArrowCollides = false;
        i = true;
    }

    public void ShootArrow(Vector3 Direction, float speed)
    {
        //Debug.Log("ArrowControl.cs : ShootArrow : Direction Vector value : " + Direction.x + ", " + Direction.y);
        setArrowDamage((speed / 20) * ArrowDamage);
        ArrowVector = Direction.normalized * speed;
        ArrowFire = true;
    }

    void Start()
    {
        ArrowRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    bool i2 = true;
    private void FixedUpdate()
    {
        if (ArrowCollides == true)
        {
            ArrowFire = false;
            setGiveDamage(false);
            if (ObjectNameDetection.HasString(collisionObjectName, "Monster"))
            {
                gameObject.SetActive(false);
            }
            //Debug.Log("collision object name : " + collisionObject.name);
            //Debug.Log("collision object Position: " + collisionObject.transform.position);
        }
        else if (ArrowFire == true)
        {
            //Debug.Log("ArrowControl : Update : 화살 속도 : " + ArrowSpeed);
            //Debug.Log("ArrowControl : Update : 화살 벡터 : " + ArrowVector.x + " / " + ArrowVector.y);
            giveDamage = true;
            ArrowRigidbody.velocity = ArrowVector;
            Invoke("UnactivateArrow", ArrowDisappearTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObjectName = collision.gameObject.name;
        Debug.Log("Arrow Control : Collision Object Name : " + collisionObjectName);
        // 이름에 Arrow와 RigidBody를 가진 객체는 무시
        if (ObjectNameDetection.HasString(collisionObjectName, "Arrow") ||
            ObjectNameDetection.HasString(collisionObjectName, "RigidBody") ||
            ObjectNameDetection.HasString(collisionObjectName, "Player"))
        {
            return;
        }

        if(ArrowFire == false)
        {
            return;
        }

        // 충돌한 객체를 설정
        if (i == true)
        {
            ArrowCollides = true;
            ArrowRigidbody.velocity = Vector2.zero;
            i = false;
        }
    }

}
