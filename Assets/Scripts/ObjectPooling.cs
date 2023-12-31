using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject PoolingTarget; // Target object to make pool.
    public int NumberOfPool;

    private List<GameObject> PoolingList;
    private int ObjectPointer = 0;

    public GameObject getFromPool()
    {
        ObjectPointer = (ObjectPointer + 1) % NumberOfPool;
        return PoolingList[ObjectPointer];
    }

    // Start is called before the first frame update
    void Start()
    {
        PoolingList = new List<GameObject>();
        for (int i = 0; i < NumberOfPool; i++)
        {
            GameObject pooledObject = Instantiate(PoolingTarget); // Before putting into the Pool, objects must be instantiated.
            pooledObject.SetActive(false); // Unactivates the objects to make it invisible unless is being used.
            PoolingList.Add(pooledObject); 
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
