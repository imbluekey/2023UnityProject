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


    private void UnactivateArrow()
    {
        gameObject.SetActive(false);
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
    }

 

    void Update()
    {
        if(ArrowCollides == true)
        {
            ArrowRigidbody.velocity = Vector3.zero;
            ArrowCollides = false;
        }
        else if (ArrowFire == true)
        {
            //Debug.Log("ArrowControl : Update : ȭ�� �ӵ� : " + ArrowSpeed);
            //Debug.Log("ArrowControl : Update : ȭ�� ���� : " + ArrowVector.x + " / " + ArrowVector.y);
            ArrowRigidbody.velocity = ArrowVector;
            Invoke("UnactivateArrow", ArrowDisappearTime);
            ArrowFire = false;
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { //when the arrow collise with the objects....
        //Debug.Log("Arrow collides with the objects . . . ");
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name != "BasicArrow(Clone)")
        {
            ArrowCollides = true;
        
        }
    }
}
