using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{

    public float ArrowDisappearTime = 5.0f;
    
    private Rigidbody2D ArrowRigidbody;
    public bool ArrowFire = false;
    private Vector3 ArrowVector;
    private bool ArrowCollides = false;
    private bool giveDamage;


    private void UnactivateArrow()
    {
        gameObject.SetActive(false);
        giveDamage = false;
        //gameObject.transform.position = Vector3.zero;
        
    }

    public void ShootArrow(Vector3 Direction ,float speed)
    {
        //Debug.Log("ArrowControl.cs : ShootArrow : Direction Vector value : " + Direction.x + ", " + Direction.y);
        ArrowVector = Direction.normalized * speed;
        ArrowFire = true;
    }

    void Start()
    {
        ArrowRigidbody = gameObject.GetComponent<Rigidbody2D>();
        giveDamage = true;
    }

 

    void Update()
    {
        if(ArrowCollides == true)
        {
            ArrowRigidbody.velocity = Vector3.zero;
            ArrowCollides = false;
            giveDamage = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    { //when the arrow collise with the objects....
        Debug.Log("Arrow collides with the objects . . . ");
        Debug.Log("collision object name : " + collision.gameObject.name);
        string collisionObject = collision.gameObject.name;
        if (collisionObject != "BasicArrow(Clone)" && !ObjectNameDetection.HasString(collisionObject, "RigidBody"))
        {
            ArrowCollides = true;
        }
    }
}
