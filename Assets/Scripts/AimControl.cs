using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControl : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 mousePosition;
    Vector2 aimOnScreen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        aimOnScreen = Camera.main.ScreenToWorldPoint(mousePosition);
        gameObject.transform.position = aimOnScreen;
    }
}
