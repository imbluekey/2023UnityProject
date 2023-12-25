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
        //ArrowRigidbody.velocity = ArrowVector.normalized * ArrowSpeed; //���ʹ� ����� ũ�⸦ ���� �����Ƿ� �������Ϳ� ũ�⸦ ���Ѵ�. 
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
        //ó������ �ӵ��� 0���� �����Ѵ�. 
    }

     //Update is called once per frame
    void Update()
    {
        if (ArrowFire)
        {  
            Vector3 ArrowVector = new Vector3(0f, 1f); // �׽�Ʈ �������� ������ ��
            ArrowVector = ArrowVector.normalized * ArrowSpeed;
            Debug.Log(">> Arrow Speed : " + ArrowSpeed + "\n");
            ArrowRigidbody.velocity = ArrowVector;
            Invoke("DestroyArrow", ArrowDisapear);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�浹 ����!");
        ArrowFire = false;
        ArrowRigidbody.velocity = Vector3.zero;
    }
}
