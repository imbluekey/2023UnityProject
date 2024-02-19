using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction_Collider_ChangeScene: MonoBehaviour
{
    public string sceneToLoad;

    private bool playerInRange = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Interaction Btn : Collision Object Name : " + collision.gameObject.name);
        if (ObjectNameDetection.HasString(collision.gameObject.name, "Player")) 
        {
            playerInRange = true;
        }
    }

    
    public void Start()
    {
    }

    private void Update()
    {
        if (playerInRange)
        {
            Debug.Log("Interaction : Changing Scene to [" + sceneToLoad + "]");
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}

