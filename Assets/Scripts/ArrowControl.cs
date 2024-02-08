using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{

    public float ArrowDisappearTime = 5.0f;
    public float ArrowDamage = 1f;
    private Rigidbody2D ArrowRigidbody;
    public bool ArrowFire = false;
    private Vector3 ArrowVector;
    private bool ArrowCollides = false;
    private bool giveDamage;

    private GameObject collisionObject;
    private Vector3 collisionObjectVector;
    private Vector3 relativePosition;
    private Vector3 collisionPosition;

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

    private void UnactivateArrow()
    {
        gameObject.SetActive(false);
        giveDamage = false;
        //gameObject.transform.position = Vector3.zero;
        
    }

    public void ShootArrow(Vector3 Direction ,float speed)
    {
        //Debug.Log("ArrowControl.cs : ShootArrow : Direction Vector value : " + Direction.x + ", " + Direction.y);
        setArrowDamage((speed / 20) * ArrowDamage);
        ArrowVector = Direction.normalized * speed;
        ArrowFire = true;
    }

    void Start()
    {
        ArrowRigidbody = gameObject.GetComponent<Rigidbody2D>();
        giveDamage = true;
        ArrowCollides = false;
    }

 

    void Update()
    {
    }
    bool i2 = true;
    private void FixedUpdate()
    {
        if(ArrowCollides == true)
        {
            setGiveDamage(false);
            Debug.Log("collision object name : " + collisionObject.name);
            Debug.Log("collision object Position: " + collisionObject.transform.position);
            if (i2 == true)
            {
                relativePosition = collisionObject.transform.position - gameObject.transform.position;
                i2 = false;
            }
            gameObject.transform.position = collisionObject.transform.position + relativePosition;
        }
        else if (ArrowFire == true)
        {
            //Debug.Log("ArrowControl : Update : 화살 속도 : " + ArrowSpeed);
            //Debug.Log("ArrowControl : Update : 화살 벡터 : " + ArrowVector.x + " / " + ArrowVector.y);
            ArrowRigidbody.velocity = ArrowVector;
            Invoke("UnactivateArrow", ArrowDisappearTime);
            ArrowFire = false;
        }
        
    }

    private bool i = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Arrow와 RigidBody를 가진 객체는 무시
        if (ObjectNameDetection.HasString(collision.gameObject.name, "Arrow") || ObjectNameDetection.HasString(collision.gameObject.name, "RigidBody"))
            return;

        //Debug.Log("OnTriggerEnter2D : collision object name : " + collision.gameObject.name);

        // 충돌한 객체를 설정
        if (i == true)
        {
            ArrowCollides = true;
            collisionObject = collision.gameObject;
            ArrowRigidbody.velocity = Vector2.zero;
            i = false;
        }
    }

}
