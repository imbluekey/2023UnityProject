using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BowControl : MonoBehaviour
{
    public GameObject Player; //public variable that indicates the "Player" GameObject.
    public GameObject MouseAim; //Variable that indicates the "Aim" GameObject.
    public ObjectPooling ArrowPool;
    public float ArrowSpeed = 5.0f;
    public Animator BowAnimator;
    public GameObject PerfectShotEffect;
    private Animator PerfectShotAnim;

    private float originalArrowSpeed;
    private GameObject Arrow;
    private Vector3 playerPosition; 
    private Vector3 BowVector;
    private float BowAngle;
    private Quaternion ArrowRotation;
    private bool ArrowHolding;
    private ArrowControl ArrowControler;

    void Start()
    {
        ArrowPool = gameObject.GetComponent<ObjectPooling>();
        ArrowHolding = false;
        originalArrowSpeed = ArrowSpeed;
        Debug.Log("Original Arrow Speed : " + originalArrowSpeed);
        PerfectShotAnim = PerfectShotEffect.GetComponent<Animator>();
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



        if (Input.GetMouseButtonDown(1) && ArrowHolding == false) 
        {
            ArrowHolding = true;
            //gets the Arrow object from the ArrowPool. Must be Activated manually.
            Arrow = ArrowPool.getFromPool();
            Arrow.SetActive(true);
            ArrowControler = Arrow.GetComponent<ArrowControl>();  
                
            BowAnimator.SetBool("BowBend", true); 


            
        }
        
        if(ArrowHolding == true )
        {
            ArrowRotation = Quaternion.Euler(0, 0, BowAngle + 135);
            Arrow.transform.rotation = ArrowRotation;
            Arrow.transform.position = gameObject.transform.position;
            if (Input.GetKeyDown(KeyCode.R))
            {
                BowAnimator.SetBool("BowBend", false);
                Arrow.SetActive(false);
                ArrowHolding = false;
                ArrowSpeed = 0;
            }
        }

        if (Input.GetMouseButtonUp(1) && ArrowHolding == true)
        {
            BowAnimator.SetBool("BowBend", false);
            ArrowControler.ShootArrow(BowVector, ArrowSpeed);
            ArrowHolding = false;
            ArrowSpeed = originalArrowSpeed;
        }


    }

    void onBowFullCharge(float ArrowSpeedWeight, int AnimationIndex)
    {
        //Debug.Log("Bow Animator is at state of Full Charge! | Arrow Speed Weight is " + ArrowSpeedWeight);
        ArrowSpeed += ArrowSpeedWeight/7;
        if(AnimationIndex >= 9)
        {
            Debug.Log("Perfect shot detected");
            //PerfectShotAnim.SetBool("PerfectTrue", true);
        }
        
    }


}
