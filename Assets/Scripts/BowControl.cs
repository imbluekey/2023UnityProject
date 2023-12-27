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


    private Animator BowAnimator;

    void Start()
    {
        Arrow.SetActive(false); // 처음에는 비활성화 시킴.
        BowAnimator = GetComponent<Animator>(); //애니메이션 컴포넌트를 가져온다. 
        
    }
    //test
    /*
     * 이 코드에서는 오브젝트 풀링 클래스를 이용하여 화살 오브젝트를 deque한다음 사용하고,
     * 사용하고 나면 enque하여 다시 비활성화 한다. 
     * deque -> 활성화 -> 사용 -> 비활성화 -> enque
     */
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


        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭 했을때
        {
            Debug.Log("화살 장전 시작");
            BowAnimator.SetBool("BowBend", true); // 활을 당기는 애니메이션 시작
            
        }
        if (!Input.GetMouseButton(0)) 
        {

        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("활 발사");

            BowAnimator.SetBool("BowBend", false); // 활을 놓음
            
            {
                Debug.Log("ArrowInstance is NULL!!!");
            }
        }


    }
}
