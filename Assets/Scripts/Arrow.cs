using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform   ArrowTransform;
    private Rigidbody2D ArrowRigidbody;
    public bool ArrowFire = false;
    public float ArrowDisapear = 5f; //Default time is 5 seconds.
    public float ArrowSpeed = 3f; //Speed of Arrow. Default value is 3f.

    private void DestroyArrow()
    {
        gameObject.SetActive(false);
    }

    public void ShootArrow()
    {
        ArrowFire = true;
        //ArrowRigidbody.velocity = ArrowVector.normalized * ArrowSpeed; //벡터는 방향과 크기를 갖고 있으므로 단위벡터에 크기를 곱한다. 
    }

    // Start is called before the first frame update
    void Awake()
    {
        ArrowTransform = GetComponent<Transform>();
        ArrowRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //ArrowRigidbody.velocity = Vector3.zero;
        //처음에는 속도를 0으로 설정한다. 
    }

     //Update is called once per frame
    void Update()
    {
        if (ArrowFire)
        {  
            Vector3 ArrowVector = new Vector3(0f, 1f); // 테스트 목적으로 설정한 값
            ArrowVector = ArrowVector.normalized * ArrowSpeed;
            Debug.Log(">> Arrow Speed : " + ArrowSpeed + "\n");
            ArrowRigidbody.velocity = ArrowVector;
            Invoke("DestroyArrow", ArrowDisapear);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌 감지!");
        ArrowFire = false;
        ArrowRigidbody.velocity = Vector3.zero;
    }
}
