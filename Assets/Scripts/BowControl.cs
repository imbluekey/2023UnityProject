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
        Arrow.SetActive(false); // ó������ ��Ȱ��ȭ ��Ŵ.
        BowAnimator = GetComponent<Animator>(); //�ִϸ��̼� ������Ʈ�� �����´�. 
        
    }
    //test 12/27
    /*
     * �� �ڵ忡���� ������Ʈ Ǯ�� Ŭ������ �̿��Ͽ� ȭ�� ������Ʈ�� deque�Ѵ��� ����ϰ�,
     * ����ϰ� ���� enque�Ͽ� �ٽ� ��Ȱ��ȭ �Ѵ�. 
     * deque -> Ȱ��ȭ -> ��� -> ��Ȱ��ȭ -> enque
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


        if (Input.GetMouseButtonDown(0)) // ���콺 ��Ŭ�� ������
        {
            Debug.Log("ȭ�� ���� ����");
            BowAnimator.SetBool("BowBend", true); // Ȱ�� ���� �ִϸ��̼� ����
            
        }
        if (!Input.GetMouseButton(0)) 
        {

        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Ȱ �߻�");

            BowAnimator.SetBool("BowBend", false); // Ȱ�� ����
            
            {
                Debug.Log("ArrowInstance is NULL!!!");
            }
        }


    }
}
