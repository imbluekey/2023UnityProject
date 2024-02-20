using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_FadeOutEffect : MonoBehaviour
{
    public float fadeDuration = 1.0f; 
    private float currentFadeTime = 0.0f; 
    private Image panelImage;
    public bool FadeOut = false;

    public void setFadeOut(bool fadeOut)
    {
        FadeOut = fadeOut;
    }

    public float getFadeDuration()
    {
        return fadeDuration;
    }

    void Start()
    {
        panelImage = GetComponent<Image>();

        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 0f);
    }

    void Update()
    {
        if(FadeOut)
        {
            currentFadeTime += Time.deltaTime;

            if (currentFadeTime >= fadeDuration)
            {
                enabled = false;
                return;
            }

            float alpha = Mathf.Lerp(0f, 1f, currentFadeTime / fadeDuration);

            panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, alpha);
        }
    }
}
