using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{

    public float ArrowDisappearTime = 5.0f;
    
    private Rigidbody2D ArrowRigidbody;
    public bool ArrowFire = false;
    public float ArrowDisapear = 5f; //Default time is 5 seconds.
    public float ArrowSpeed = 3f; //Speed of Arrow. Default value is 3f.
    private Quaternion ArrowRotation;
    private Vector3 ArrowVector;
    private bool ArrowCollides = false;


    private void UnactivateArrow()
    {
        gameObject.SetActive(false); 
        gameObject.transform.position = Vector3.zero;
    }

    public void ShootArrow(Vector3 Direction, Quaternion rotaion ,float speed)
    {
        //Debug.Log("ArrowControl.cs : ShootArrow : Direction Vector value : " + Direction.x + ", " + Direction.y);
        ArrowVector = Direction.normalized * speed;
        ArrowFire = true;
    }

    void Start()
    {
        ArrowRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

 

    void Update()
    {
        if(ArrowCollides == true)
        {
            ArrowRigidbody.velocity = Vector3.zero;

        }
        else if (ArrowFire == true)
        {
            //Debug.Log("ArrowControl : Update : 화살 속도 : " + ArrowSpeed);
            //Debug.Log("ArrowControl : Update : 화살 벡터 : " + ArrowVector.x + " / " + ArrowVector.y);
            ArrowRigidbody.velocity = ArrowVector;
            Invoke("UnactivateArrow", ArrowDisappearTime);
            
        }
        else
        {
            //setRigidBodyVelocity(Vector3.zero);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { //when the arrow collise with the objects....
        Debug.Log("Arrow collides with the objects . . . ");
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name != "BasicArrow(Clone)")
        {
            ArrowCollides = true;
        
        }
    }
}
