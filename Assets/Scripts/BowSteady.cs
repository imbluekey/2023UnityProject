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
        BowAnimator = GetComponent<Animator>(); //애니메이션 컴포넌트를 가져온다. 
        ArrowPool = GetComponent<ArrowPool>();
        ArrowInstance = new Arrow[NumberOfObject];
    }

    /*
     * 이 코드에서는 오브젝트 풀링 클래스를 이용하여 화살 오브젝트를 deque한다음 사용하고,
     * 사용하고 나면 enque하여 다시 비활성화 한다. 
     * deque -> 활성화 -> 사용 -> 비활성화 -> enque
     */
    void Update()
    {

        Vector3 playerPosition = Player.transform.position;
        //Gets the position of Player GameObject. 
        gameObject.transform.position = new Vector3(playerPosition.x + 1f, playerPosition.y + 0.2f);
        //Sets the position of "Bow" objects relative to "Player" object.

        

        if (Input.GetMouseButton(0))
        { // 활 시위를 당기기 시작했을 때, > 마우스 좌클릭 했을때, 
            BowAnimator.SetBool("BowBend", true);
            if( ! ArrowReloaded )
            {
                ArrowReloaded = true;

                ArrowInstance[i] = ArrowPool.GetObject();
                //i++;
                
                //화살 프리팹을 enque해야 하는 곳. 
                Debug.Log("화살 인스턴스 생성 . . . ");

            }

            Debug.Log("화살 시위 당기는 중 . . .");
        }
        else if (Input.GetMouseButtonUp(0) && BowAnimator.GetBool("BowBend"))
        { // 활 시위를 놓았을때 > 마우스를 누르다가 땠을경우. 
            BowAnimator.SetBool("BowBend", false);
            Debug.Log("화살 시위 놓음.");
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
                Debug.Log("화살 반환중 . . .  ");
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
