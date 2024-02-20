using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_FadeInEffect : MonoBehaviour
{
    public float fadeDuration = 1.0f; 
    private float currentFadeTime = 0.0f; 
    private Image panelImage; 

    void Start()
    {
        panelImage = GetComponent<Image>();

        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 1f);
    }

    void Update()
    {
        currentFadeTime += Time.deltaTime;

        if (currentFadeTime >= fadeDuration)
        {
            enabled = false;
            return;
        }

        float alpha = Mathf.Lerp(1f, 0f, currentFadeTime / fadeDuration);

        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, alpha);
    }
}
