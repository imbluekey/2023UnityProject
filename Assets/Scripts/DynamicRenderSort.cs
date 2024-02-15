using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicRenderSort : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 ObjectBottomPoint;
    private Vector3 ObjectsBoundsDistance;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ObjectsBoundsDistance = new Vector3(0f, spriteRenderer.bounds.extents.y, 0f);
        //Debug.Log("Object Bounds Extents Distance : " + ObjectsBoundsDistance);
    }

    void Update()
    {
        ObjectBottomPoint = gameObject.transform.position - ObjectsBoundsDistance ;
        //Debug.Log("Object name : " + gameObject.name +" / Bound bottom coordinate : " + ObjectBottomPoint);
        spriteRenderer.sortingOrder = Mathf.RoundToInt(ObjectBottomPoint.y)*-1;
    }
}
