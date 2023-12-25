using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowPool2 : MonoBehaviour
{
    public int NumberOfObjects = 10; // default is 10

    [SerializeField]
    private GameObject PrefabOfPoolingObject;

    private Queue<ArrowControl> PoolingQueue = new Queue<ArrowControl>();

    public GameObject Bow;
    // Start is called before the first frame update
    public void Awake()
    {
        Initialize(NumberOfObjects);
        Debug.Log("Object pool : Awake함수 실행됨 . ");
    }

    private ArrowControl CreatNewObject()
    {
        Debug.Log("Object pool : Create New Arrow 함수 실행됨 / 프리팹 이름 : " + PrefabOfPoolingObject.name);
        var newArrow = Instantiate(PrefabOfPoolingObject, transform).GetComponent<ArrowControl>();
        transform.SetParent(Bow.transform, false);
        newArrow.gameObject.SetActive(false);
        return newArrow;
    }

    private void Initialize(int count)
    {
        Debug.Log("Object pool : Initialize함수 실행됨 . ");

        for (int i = 0; i < count; i++)
        {
            PoolingQueue.Enqueue(CreatNewObject());
        }
    }

    public ArrowControl GetObject()
    {
        Debug.Log("Before Dequeue, Size of Queue : " + PoolingQueue.Count);
        if (PoolingQueue.Count > 0)
        { //아직 빌려줄 수 있는 화살 오브젝트가 남아 있을 때
            var newArrow = PoolingQueue.Dequeue();
            //newArrow.transform.SetParent(gameObject.transform);
            newArrow.gameObject.SetActive(true);
            return newArrow;
        }
        else
        { //빌려줄 수 있는 화살 오브젝트가 부족할 때 
            var newArrow = CreatNewObject();
            //newArrow.transform.SetParent(gameObject.transform);
            newArrow.gameObject.SetActive(true);
            return newArrow;
        }
    }

    public void ReturnObject(ArrowControl Arrow)
    {
        PoolingQueue.Enqueue(Arrow);
        //DeActivateObject(Arrow);
        Debug.Log("After enqueue, Size of Queue : " + PoolingQueue.Count);

    }

    private void DeActivateObject(ArrowControl Arrow)
    {
        Arrow.gameObject.SetActive(false );
    }
}
