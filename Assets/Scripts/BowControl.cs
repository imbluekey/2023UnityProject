using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BowControl : MonoBehaviour
{
    public GameObject Player; //public variable that indicates the "Player" GameObject.
    public GameObject MouseAim; //Variable that indicates the "Aim" GameObject.
    public ObjectPooling ArrowPool;


    private GameObject Arrow;
    private Vector3 playerPosition; 
    private Vector3 BowVector;
    private float BowAngle;
    private Quaternion ArrowRotation;
    private bool ArrowHolding;
    private ArrowControl ArrowControler;


    private Animator BowAnimator;

    void Start()
    {
        ArrowPool = gameObject.GetComponent<ObjectPooling>();
        //Arrow = Instantiate(Arrow);
        //Arrow.SetActive(false); 
        BowAnimator = GetComponent<Animator>();
        ArrowHolding = true;
    }

       
    void Update()
    {

        playerPosition = Player.transform.position;
        playerPosition.y -= 0.1f;
        //Gets the position of Player GameObject. 



        //sets the Vector and Angle of the bow.
        BowVector = (MouseAim.transform.position - playerPosition).normalized; 
        BowAngle = Mathf.Atan2(BowVector.y, BowVector.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0,0, BowAngle + 45);
        //Sets the rotation of "Bow" objects relative to "Player" and "Aim" object.
        gameObject.transform.position = playerPosition + BowVector*0.3f;
        //Sets the position of "Bow" objects relative to "Player" object.

        
        
        if(ArrowHolding == true && Arrow != null)
        {
            ArrowRotation = Quaternion.Euler(0, 0, BowAngle + 135);
            Arrow.transform.rotation = ArrowRotation;
            Arrow.transform.position = gameObject.transform.position;
        }

       
        if (Input.GetMouseButtonDown(0)) 
        {
            ArrowHolding = true;

            //gets the Arrow object from the ArrowPool. Must be Activated manually.
            Arrow = ArrowPool.getFromPool();
            Arrow.SetActive(true);
            ArrowControler = Arrow.GetComponent<ArrowControl>();  
                
            BowAnimator.SetBool("BowBend", true); 


            
        }
        //test1234
        if (!Input.GetMouseButton(0)) 
        {

        }
        if (Input.GetMouseButtonUp(0))
        {

            ArrowHolding = false;
            BowAnimator.SetBool("BowBend", false);
            ArrowControler.ShootArrow(BowVector, ArrowRotation, 3.0f);


            {
                //Debug.Log("ArrowInstance is NULL!!!");
            }
        }


    }
}
