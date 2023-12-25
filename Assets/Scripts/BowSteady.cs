using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BowSteady : MonoBehaviour
{
    public  GameObject Arrow; //public variable that indicates the Prefab of "Arrow"
    public  GameObject Player; //public variable that indicates the "Player" GameObject.
    public float ArrowDisapearTime = 5f;
    private Animator   BowAnimator;
    public const int NumberOfObject = 10;
    private int i = 0;
    private Arrow[] ArrowInstance;
    private ArrowPool ArrowPool;
    private bool ArrowReloaded  = false;

    void Start()
    {
        BowAnimator = GetComponent<Animator>(); //�ִϸ��̼� ������Ʈ�� �����´�. 
        ArrowPool = GetComponent<ArrowPool>();
        ArrowInstance = new Arrow[NumberOfObject];
    }

    /*
     * �� �ڵ忡���� ������Ʈ Ǯ�� Ŭ������ �̿��Ͽ� ȭ�� ������Ʈ�� deque�Ѵ��� ����ϰ�,
     * ����ϰ� ���� enque�Ͽ� �ٽ� ��Ȱ��ȭ �Ѵ�. 
     * deque -> Ȱ��ȭ -> ��� -> ��Ȱ��ȭ -> enque
     */
    void Update()
    {

        Vector3 playerPosition = Player.transform.position;
        //Gets the position of Player GameObject. 
        gameObject.transform.position = new Vector3(playerPosition.x + 1f, playerPosition.y + 0.2f);
        //Sets the position of "Bow" objects relative to "Player" object.

        

        if (Input.GetMouseButton(0))
        { // Ȱ ������ ���� �������� ��, > ���콺 ��Ŭ�� ������, 
            BowAnimator.SetBool("BowBend", true);
            if( ! ArrowReloaded )
            {
                ArrowReloaded = true;

                ArrowInstance[i] = ArrowPool.GetObject();
                //i++;
                
                //ȭ�� �������� enque�ؾ� �ϴ� ��. 
                Debug.Log("ȭ�� �ν��Ͻ� ���� . . . ");

            }

            Debug.Log("ȭ�� ���� ���� �� . . .");
        }
        else if (Input.GetMouseButtonUp(0) && BowAnimator.GetBool("BowBend"))
        { // Ȱ ������ �������� > ���콺�� �����ٰ� �������. 
            BowAnimator.SetBool("BowBend", false);
            Debug.Log("ȭ�� ���� ����.");
            ArrowInstance[i].ShootArrow();
            ArrowReloaded = false; 
            // Sets the ArrowReloaded as false so that player can reloaded "Arrow" again.

        }

        if(ArrowReloaded)
        {
            ArrowInstance[i].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.4f);
            ArrowInstance[i].transform.rotation = Quaternion.Euler(0f, 0f, 225f);
        }
        
        if (!ArrowReloaded && (ArrowInstance[i] != null))
        {
            if(ArrowInstance[i].isActiveAndEnabled == false)
            {
                Debug.Log("ȭ�� ��ȯ�� . . .  ");
                ArrowPool.ReturnObject(ArrowInstance[i]);
                //i++;
                ArrowInstance = null;
            }
        }

        if (i >= NumberOfObject)
        {
            i = 0;
        }

    }
}
