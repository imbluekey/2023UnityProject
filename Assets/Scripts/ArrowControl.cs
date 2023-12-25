using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    private Transform   ArrowTransform;
    private Rigidbody2D ArrowRigidbody;
    public bool ArrowFire = false;
    public float ArrowDisapear = 5f; //Default time is 5 seconds.
    public float ArrowSpeed = 3f; //Speed of Arrow. Default value is 3f.
    private Quaternion ArrowRotation;
    private Vector3 ArrowVector;

    private void DestroyArrow()
    {
        ArrowFire = false;
        gameObject.SetActive(false);
    }

    public void setArrowDisapear(float disapearTime)
    {
        ArrowDisapear = disapearTime;
    }

    private void setRigidBodyVelocity(Vector3 velocity)
    {
        ArrowRigidbody.velocity = velocity;
    }

    public void ShootArrow(Vector3 Direction, Quaternion rotaion ,float speed)
    {
        Debug.Log("ArrowControl.cs : ShootArrow : Direction Vector value : " + Direction.x + ", " + Direction.y);
        Debug.Log("ArrowControl : ShootArrow : 화살 벡터 : " + Direction.x + " / " + Direction.y);

        ArrowVector = Direction.normalized * speed;
        ArrowFire = true;
    }

    void Start()
    {
        ArrowTransform = GetComponent<Transform>();
        ArrowRigidbody = GetComponent<Rigidbody2D>();
    }

 

    void Update()
    {

        if (ArrowFire)
        {  
            Debug.Log("ArrowControl : Update : 화살 속도 : " + ArrowSpeed);
            Debug.Log("ArrowControl : Update : 화살 벡터 : " + ArrowVector.x +" / " + ArrowVector.y);

            setRigidBodyVelocity(ArrowVector);
            Invoke("DestroyArrow", ArrowDisapear);
            //ArrowFire = false;
        }
        else
        {
            //setRigidBodyVelocity(Vector3.zero);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌 감지!");
        ArrowFire = false;
        ArrowRigidbody.velocity = Vector3.zero;
    }
}
