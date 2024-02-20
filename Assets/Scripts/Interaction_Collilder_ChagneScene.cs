using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction_Collider_ChangeScene: MonoBehaviour
{
    public string sceneToLoad;
    public GameObject Panel;
    private string findingObjectName = "Panel";
    private float FadeOutDuration;
    private Scene_FadeOutEffect Scene_FadeOutEffect;

    private bool playerInRange = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Interaction Btn : Collision Object Name : " + collision.gameObject.name);
        if (ObjectNameDetection.HasString(collision.gameObject.name, "Player")) 
        {
            playerInRange = true;
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);

    }
    
    public void Start(){
        if(Panel == null)
        {
            Debug.LogWarning("Panel Object Reference is missing.");
        }
        Scene_FadeOutEffect = Panel.GetComponent<Scene_FadeOutEffect>();
    }

    private void Update()
    {
        if (playerInRange && (Panel != null))
        {
            Debug.Log("Interaction : Changing Scene to [" + sceneToLoad + "]");
            FadeOutDuration = Scene_FadeOutEffect.getFadeDuration();
            Scene_FadeOutEffect.setFadeOut(true);
            Invoke("ChangeScene", FadeOutDuration);
        }
    }

}

