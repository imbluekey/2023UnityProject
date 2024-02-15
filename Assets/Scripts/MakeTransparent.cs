using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MakeTransparent : MonoBehaviour
{
    private TilemapRenderer Renderer;
    private Material material;
    private Color colorAlpha;

    public float alpha = 0.5f;
    void Start()
    {
        Renderer = GetComponent<TilemapRenderer>();
        material = Renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        colorAlpha = material.color;
        colorAlpha.a = alpha;
        material.color = colorAlpha;
        Renderer.material = material;
    }
}
