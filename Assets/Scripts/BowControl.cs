using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BowControl : MonoBehaviour
{
    public GameObject Player; //public variable that indicates the "Player" GameObject.
    public GameObject MouseAim; //Variable that indicates the "Aim" GameObject.
    public GameObject Arrow;

    private Vector3 playerPosition; 
    private Vector3 BowVector;
    private float BowAngle;
    private Quaternion ArrowRotation;
    private bool ArrowHolding;
    private ArrowControl ArrowControler;


    private Animator BowAnimator;

    void Start()
    {
        Arrow = Instantiate(Arrow);
        Arrow.SetActive(false); 
        BowAnimator = GetComponent<Animator>();
        ArrowHolding = true;
        ArrowControler = Arrow.GetComponent<ArrowControl>();
    }
    void Update()
    {

        playerPosition = Player.transform.position;
        playerPosition.y -= 0.1f;
        //Gets the position of Player GameObject. 

        BowVector = (MouseAim.transform.position - playerPosition).normalized;
        //Debug.Log("BowVector x : " + BowVector.x);
        //Debug.Log("BowVector z : " + BowVector.z);

        BowAngle = Mathf.Atan2(BowVector.y, BowVector.x) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.Euler(0,0, BowAngle + 45);
        //Sets the rotation of "Bow" objects relative to "Player" and "Aim" object.
        gameObject.transform.position = playerPosition + BowVector*0.3f;
        //Sets the position of "Bow" objects relative to "Player" object.
        
        
        if(ArrowHolding == true)
        {
            ArrowRotation = Quaternion.Euler(0, 0, BowAngle + 135);
            Arrow.transform.rotation = ArrowRotation;
            Arrow.transform.position = gameObject.transform.position;
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            ArrowHolding = true;
            Arrow.SetActive(true);
            Debug.Log("화살 장전 시작");
            BowAnimator.SetBool("BowBend", true); 
            
        }
        if (!Input.GetMouseButton(0)) 
        {

        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("활 발사");
            ArrowHolding = false;
            BowAnimator.SetBool("BowBend", false);
            ArrowControler.ShootArrow(BowVector, ArrowRotation, 3.0f);

            {
                Debug.Log("ArrowInstance is NULL!!!");
            }
        }


    }
}
