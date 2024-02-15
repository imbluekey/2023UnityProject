using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveDynamicToObjects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        spriteRenderer.sortingOrder = Mathf.CeilToInt(gameObject.transform.position.y)*-1;
        
    }
}
