using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarPositionUpdater : MonoBehaviour
{
    public GameObject target;
    public float offset = 0;
    private Vector3 OffsetVector;
    private SpriteRenderer spriteRenderer;
    private Vector3 ObjectCeilingPoint;
    private Vector3 ObjectsBoundsDistance;

    void Start()
    {
        OffsetVector = new Vector3(0f, offset, 0f);
        spriteRenderer = target.GetComponent<SpriteRenderer>();
        ObjectsBoundsDistance = new Vector3(0f, spriteRenderer.bounds.extents.y, 0f);
        Debug.Log("Static Object Bound Distance " + ObjectsBoundsDistance);
    }

    // Update is called once per frame
    void Update()
    {
        ObjectCeilingPoint = target.transform.position + ObjectsBoundsDistance;
        gameObject.transform.position = ObjectCeilingPoint + OffsetVector;
    }
}
