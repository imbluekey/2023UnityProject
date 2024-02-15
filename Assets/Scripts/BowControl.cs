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
    public GameObject PerfectShotAnimation; //Animation Object of Perfect shot.
    public ObjectPooling ArrowPool;
    public float ArrowSpeed;
    public Animator BowAnimator;

    private float originalArrowSpeed;
    private GameObject Arrow;
    private Vector3 playerPosition; 
    private Vector3 BowVector;
    private float BowAngle;
    private Quaternion ArrowRotation;
    private bool ArrowHolding;
    private ArrowControl ArrowControler;
    private int AnimationIndex;

    public void PlayAnimation()
    {
        PerfectShotAnimation.GetComponent<PerfectShotEffectController>().PlayAnimation();
    }

    void Start()
    {
        ArrowPool = gameObject.GetComponent<ObjectPooling>();
        ArrowHolding = false;
        originalArrowSpeed = ArrowSpeed;
        Debug.Log("Original Arrow Speed : " + originalArrowSpeed);
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
            ArrowControler = Arrow.GetComponent<ArrowControl>();
            ArrowControler.ActivateArrow();  
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
            Debug.Log("Animation Index : " + AnimationIndex);
            if(5 < AnimationIndex)
            {
                Debug.Log("Shoot");
                BowAnimator.SetBool("BowBend", false);
                ArrowControler.ShootArrow(BowVector, ArrowSpeed);
                ArrowHolding = false;
                ArrowSpeed = originalArrowSpeed;
            }
            else
            {
                BowAnimator.SetBool("BowBend", false);
                Arrow.SetActive(false);
                ArrowHolding = false;
                ArrowSpeed = 0;
            }
        }


    }

    void onBowFullCharge(int AnimationIndex)
    {
        Debug.Log("In Function Animation Index : " + AnimationIndex);
        this.AnimationIndex = AnimationIndex;
        float speedParameter = 1f;
        //Debug.Log("Bow Animator is at state of Full Charge! | Arrow Speed Weight is " + ArrowSpeedWeight);
        switch (AnimationIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4: 
                break;
            case 5:
                break;
            case 6:
                speedParameter = 1.1f;
                break; 
            case 7:
                speedParameter = 1.13f;
                break; 
            case 8:
                speedParameter = 1.18f;
                break;
            case 9:
                speedParameter = 1.6f;
                break; 
            case 10:
                speedParameter = 1.6f;
                break;
            case 11:
                speedParameter = 1.7f;
                break;
            default:
                break;
        }
        ArrowSpeed = ArrowSpeed * speedParameter;

        
    }


}
