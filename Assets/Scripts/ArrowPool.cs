using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowPool : MonoBehaviour
{
    public int NumberOfObjects = 10; // default is 10

    [SerializeField]
    private GameObject PrefabOfPoolingObject;

    private Queue<Arrow> PoolingQueue = new Queue<Arrow>();
    // Start is called before the first frame update
    public void Awake()
    {
        Initialize(NumberOfObjects);
        Debug.Log("Object pool : Awake�Լ� ����� . ");
    }

    private Arrow CreatNewObject()
    {
        Debug.Log("Object pool : Create New Arrow �Լ� ����� . ");
        Debug.Log(PrefabOfPoolingObject.name);
        var newArrow = Instantiate(PrefabOfPoolingObject, transform).GetComponent<Arrow>();
        
        newArrow.gameObject.SetActive(false);
        return newArrow;
    }
    //is it working good?
    private void Initialize(int count)
    {
        Debug.Log("Object pool : Initialize�Լ� ����� . ");

        for (int i = 0; i < count; i++)
        {
            PoolingQueue.Enqueue(CreatNewObject());
        }
    }

    public Arrow GetObject()
    {
        Debug.Log("Before Dequeue, Size of Queue : " + PoolingQueue.Count);
        if (PoolingQueue.Count > 0)
        { //���� ������ �� �ִ� ȭ�� ������Ʈ�� ���� ���� ��
            var newArrow = PoolingQueue.Dequeue();
            //newArrow.transform.SetParent(gameObject.transform);
            newArrow.gameObject.SetActive(true);
            return newArrow;
        }
        else
        { //������ �� �ִ� ȭ�� ������Ʈ�� ������ �� 
            var newArrow = CreatNewObject();
            //newArrow.transform.SetParent(gameObject.transform);
            newArrow.gameObject.SetActive(true);
            return newArrow;
        }
    }

    public void ReturnObject(Arrow Arrow, float time = 0f)
    {
        //Arrow.gameObject.SetActive(false);
        //Invoke("DeActivateObject", time);
        //Arrow.transform.SetParent(gameObject.transform);
        PoolingQueue.Enqueue(Arrow);
        Debug.Log("After enqueue, Size of Queue : " + PoolingQueue.Count);

    }

    private void DeActivateObject(Arrow Arrow)
    {
        Arrow.gameObject.SetActive(false );
    }
}
